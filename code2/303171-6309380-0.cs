    private String DownloadData(String URL, Dictionary<String, String> Parameters)
    {
        String postString = String.Empty;
        foreach (KeyValuePair<string, string> postValue in Parameters)
        {
            foreach (char c in postValue.Value)
            { postString += String.Format("{0}={1}&", postValue.Key, postValue.Value); }
        }
        postString = postString.TrimEnd('&');
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(URL);
        webRequest.Method = "POST";
        webRequest.ContentLength = postString.Length;
        webRequest.ContentType = "application/x-www-form-urlencoded";
        StreamWriter streamWriter = null;
        streamWriter = new StreamWriter(webRequest.GetRequestStream());
        streamWriter.Write(postString);
        streamWriter.Close();
        String postResponse;
        
        HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
        using (StreamReader responseStream = new StreamReader(webResponse.GetResponseStream()))
        {
            postResponse = responseStream.ReadToEnd();
            responseStream.Close();
        }
        return postResponse;
    }
