    //https://drive.google.com/file/d//view?usp=sharing
    //16NiBSZo7kuX6UqmOE1iJHUrmXJXDGFNC
    //https://drive.google.com/uc?export=download&id=16NiBSZo7kuX6UqmOE1iJHUrmXJXDGFNC
    public string url;
	public static GameObject Gears;
	public Text loadingText;
    //AssetBundle MatBundle;
    //public Transform spawnPos;
    public bool mClearCache = false;
    void Awake()
    {
        Caching.ClearCache();
        if (mClearCache)
            Caching.ClearCache();
    }
    void Updat()
    {
        
    }
    IEnumerator LoadBundle(string GearName) 
	{
	    while (!Caching.ready)
	    {
			yield return null;
	    }
        //MATERIAL
        //WWW ww = new WWW(Mat);
        //yield return ww;
        //if (ww.error != null)
        //{
        //    throw new System.Exception("Theres as error: " + ww.error);
        //}
        //MatBundle = ww.assetBundle;
        //MatBundle.LoadAllAssets();
        //MATERIAL
        //Begin download
        WWW www = WWW.LoadFromCacheOrDownload (url, 0);
	    yield return www;
	    //Load the downloaded bundle
	    AssetBundle bundle = www.assetBundle;
        //Load an asset from the loaded bundle
        AssetBundleRequest bundleRequest = bundle.LoadAssetAsync(GearName, typeof(GameObject));
        yield return bundleRequest;
        
        //AssetBundleRequest bundleRequest = bundle.LoadAssetAsync(GearName, typeof(GameObject));
        //get object
        GameObject obj = bundleRequest.asset as GameObject;
        // Gear = Instantiate(obj,spawnPos.position, Quaternion.identity) as GameObject;
        Gears = Instantiate(obj) as GameObject;
        
        loadingText.text = "";
        bundle.Unload(false);
        //www.Dispose();
	}
	public void Load(string GearName)
	{
        if (Gears)
        {
            Destroy(Gears);
        }
        loadingText.text = "Loading...";
		StartCoroutine(LoadBundle(GearName));
        
	}
   
}
