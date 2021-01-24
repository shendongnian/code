public IEnumerator GetAssetBundleByRawBytes(string url, Action<AssetBundle> onSuccess)
{
    using (UnityWebRequest uwr = UnityWebRequest.Get(url))
    {
        yield return uwr.SendWebRequest();
        var bundle =AssetBundle.LoadFromMemory(uwr.downloadHandler.data);
        if (onSuccess != null)
            onSuccess(bundle);
    }
}
