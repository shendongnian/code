    void Start () {
        StartCoroutine (GetRequest ("cont.txt"));
    }
    IEnumerator GetRequest (string file_name) {
        // use concat with joining strings
        var uri = string.Concat ("http://www.mordazah.com/", file_name);
        using (var webRequest = UnityWebRequest.Get (uri)) {
            yield return webRequest.SendWebRequest (); // send is deprecated
            if (webRequest.isNetworkError) {
                Debug.LogError (webRequest.error);
            }
            else {
                // ensure you have this directory - will not throw if it exists
                Directory.CreateDirectory (Application.streamingAssetsPath);
                // create the appropriate path to save to using Path.Combine()
                var savePath = Path.Combine (Application.streamingAssetsPath, file_name);
                File.WriteAllText (savePath, webRequest.downloadHandler.text);
            }
        }
    }
