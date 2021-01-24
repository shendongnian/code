    IEnumerator DownloadAsset()
    {
        string url = here the URL for asset bundle;
        using (var uwr = new UnityWebRequest(url, UnityWebRequest.kHttpVerbGET))
        {
            uwr.downloadHandler = new DownloadHandlerAssetBundle(url, 36, 0);
            var operation = uwr.SendWebRequest();
            
            while (!operation.isDone)
            {
                progressBar.color = Color.red;
                downloadDataProgress = uwr.progress * 100;
                progressBar.fillAmount = downloadDataProgress / 100;
                print("Download: " + downloadDataProgress);
                yield return null;
            }
    
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(uwr);
            {
                print("Get asset from bundle...");
            }
    
            //Load scene
            uwr.Dispose();
            print("ready to Load scene from asset...");
            StartCoroutine(LoadSceneProgress("Example"));
            bundle.Unload(false);
        }
    }
