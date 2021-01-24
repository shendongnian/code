       UnityWebRequest www = UnityWebRequest.GetAssetBundle("website Name to get the asset bundle");
       yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            // Error fetching the asset bundle from the website.
        }
        else {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
            GameObject temp = bundle.LoadAsset(assetName) as GameObject;
            if (temp != null){
                Instantiate(temp);
            } else {
                // Failed to convert to gameObject
            }
        }
