    string googleUriPattern =
            "http://ajax.googleapis.com/ajax/services/search/web?v=1.0&safe=off&rsz=large&userip={0}&q={1}";
    var requestUri = new Uri(
        string.Format(
            googleUriPattern,
            "A valid IP address",
            "query"
        ));
    var httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);
    httpWebRequest.Timeout = 5000;
    using (var webResponse = httpWebRequest.GetResponse())
    using (var sr = new StreamReader(webResponse.GetResponseStream()))
    {
        var result = JsonConvert.DeserializeXNode(sr.ReadToEnd(), "responseData");
        var searchResultCount = Convert.ToInt32((string)result.Descendants("estimatedResultCount").FirstOrDefault());
    }
