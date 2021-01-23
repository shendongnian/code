    HttpWebRequest GetRequest(String url, NameValueCollection nameValueCollection)
    {
        // Here we convert the nameValueCollection to POST data.
        // This will only work if nameValueCollection contains some items.
        var parameters = new StringBuilder();
        foreach (var key in nameValueCollection)
        {
            parameters.AppendFormat("{0}={1}&", 
                HttpUtility.UrlEncode(key), 
                HttpUtility.UrlEncode(nameValueCollection[key]));
        }
        parameters.Length -= 1;
        // Here we create the request and write the POST data to it.
        var request = (HttpWebRequest)HttpWebRequest.Create(url);
        request.Method = "POST";
    
        using (var writer = new StreamWriter(request.GetRequestStream()))
        {
            writer.Write(parameters.ToString());
        }
        return request;
    }
