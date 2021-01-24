    public System.Collections.IEnumerator DownloadAsset(string url, string assetName)
	{
		using (var uwr = new UnityEngine.Networking.UnityWebRequest(url, UnityEngine.Networking.UnityWebRequest.kHttpVerbGET))
		{
			uwr.downloadHandler = new UnityEngine.Networking.DownloadHandlerAssetBundle(url, 0);
			yield return uwr.SendWebRequest();
			AssetBundle bundle = UnityEngine.Networking.DownloadHandlerAssetBundle.GetContent(uwr);
			if (bundle != null)
			{
				AGUIMisc.ShowToast("Not Null");
				GameObject temp = bundle.LoadAsset<GameObject>(assetName);
				var newobj = GameObject.Instantiate(temp);
				newobj.transform.parent = maleparent.transform;
			}
			else
			{
				AGUIMisc.ShowToast("Null");
			}
		}
	}
