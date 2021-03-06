using UnityEngine;
using System.Collections;

public class xinshoucun_setobj_texture : WorldObjectLoadCB
{
	public Texture texture;
	public override void onWorldObjectLoadCB(UnityEngine.Object obj)
	{
		UnityEngine.GameObject go = (UnityEngine.GameObject)obj;
		MeshRenderer render = go.GetComponent<MeshRenderer>();
		
		if(render == null)
		{
			setChild(go);
			return;
		}
		
		setTexture(render);
		setChild(go);
	}
	
	void setChild(UnityEngine.GameObject go)
	{
		foreach(Transform child in go.transform)
		{
			setChild(child.gameObject);
			
			MeshRenderer render = child.gameObject.GetComponent<MeshRenderer>();
			
			if(render == null)
				continue;
			
			setTexture(render);
		}
	}
	
	void setTexture(MeshRenderer render)
	{
		render.sharedMaterial.SetTexture("_MainTex", texture);
		render.sharedMaterial.SetTexture("_Detail", texture);
	}
}

public class xinshoucun_worldmgr : MonoBehaviour {
	public Texture texture;
	
	void Awake ()   
	{
		Common.DEBUG_MSG("xinshoucun_worldmgr::Awake()");
		xinshoucun_setobj_texture cb = new xinshoucun_setobj_texture();
		cb.texture = texture;
		WorldManager.currinst.worldObjectLoadCB = cb;
	}
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
