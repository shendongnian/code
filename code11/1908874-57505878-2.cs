    private static bool alreadyLoading;
    private static AssetBundle assetBundle;
    void Start()
    {
        // only load the bundle once
        if(!alreadyLoading) 
        {
            // set the flag to make sure this is never done again
            alreadyLoading = true;
            StartCoroutine(LoadAsset(nameOfAssetBundle, nameOfObjectToLoad));
        }
        else
        {
            LoadObjectFromBundle(nameOfOjectToLoad);
        }
    } 
    private IEnumerator LoadAsset(string assetBundleName, string objectNameToLoad)
    {
        string filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "AssetBundles");
        filePath = System.IO.Path.Combine(filePath, assetBundleName);
        var assetBundleCreateRequest = AssetBundle.LoadFromFileAsync(filePath);
        yield return assetBundleCreateRequest;
        assetBundle = assetBundleCreateRequest.assetBundle;
        LoadObjectFromBundle(objectNameToLoad);
    }
    private IEnumerator LoadObjectFromBundle(string objectNameToLoad)
    {
        AssetBundleRequest assetRequest = assetBundle.LoadAssetAsync<GameObject>(objectNameToLoad);
        yield return assetRequest;
        GameObject loadedAsset = (GameObject)assetRequest.asset;
        model = loadedAsset.GetComponent<AnchorBehavior>();
    }
