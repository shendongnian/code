UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(assetsFilepath);
www.SendWebRequest();
while (!www.isDone)
{
    Debug.Log("Downloading asset: " + www.downloadProgress);
}
if (www.error == null)
{
    string tempPath = Path.Combine(Application.persistentDataPath, assetsFilename);
    FileStream cache = new FileStream(path, FileMode.Create);
    cache.Write(www.downloadHandler.data, 0, www.downloadHandler.data.Length);
    cache.Close();
}
