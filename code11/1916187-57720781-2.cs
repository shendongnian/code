    private IEnumerator LoadAsset(string assetBundleName, string objectNameToLoad)
    {
        // can be done in one single call
        var filePath = System.IO.Path.Combine(Application.streamingAssetsPath, "AssetBundles", assetBundleName);
        // if at this point the assetBundle is already set we can skip the loading
        // and directly continue to load the specific object
        if (!assetBundle)
        {
            var assetBundleCreateRequest = AssetBundle.LoadFromFileAsync(filePath);
            yield return assetBundleCreateRequest;
            assetBundle = assetBundleCreateRequest.assetBundle;
            if (!assetBundle)
            {
                Debug.LogError("Failed! assetBundle could not be loaded!", this);
            }
        }
        else
        {
            Debug.Log("assetBundle is already loaded! Skipping", this);
        }
        // YOU ALSO MISSED THIS!!
        yield return LoadObjectFromBundle(objectNameToLoad);
    }
    private IEnumerator LoadObjectFromBundle(string objectNameToLoad)
    {
        // This time we wait until the assetBundle is actually set to a valid value
        // you could simply use
        //yield return new WaitUntil(() => assetBundle != null);
        // but just to see what happens I would let them report in certain intervals like
        var timer = 0f;
        while (!assetBundle)
        {
            timer += Time.deltaTime;
            if (timer > 3)
            {
                timer = 0;
                Debug.Log("Still waiting for assetBundle ...", this);
            }
            yield return null;
        }
        var assetRequest = assetBundle.LoadAssetAsync<GameObject>(objectNameToLoad);
        yield return assetRequest;
        var loadedAsset = (GameObject)assetRequest.asset;
        model = loadedAsset.GetComponent<AnchorBehaviour>();
        // add a final check
        if(!model)
        {
            Debug.LogError("Failed to load object from assetBundle!", this);
        }
        else
        {
            Debug.Log("Successfully loaded model!", this);
        }
    }
    // and now make sure you can't click before model is actually set
    public void create()
    {
        if(!model)
        {
            Debug.LogWarning("model is not loaded yet ...", this);
            return;
        }
        planeFinder.AnchorStage = model;
    }
