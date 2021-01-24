    var request = (HttpWebRequest)WebRequest.Create(uri);
    request.Method = HttpMethod.Post.ToString();
    request.ContentType = "application/json";
    
    // replace name1, name2, value1, value2 with the 
    // key value pairs that need to be posted.
    var content = $"{name1}={value1}&{name2}={value2}"
    using (var writer = new StreamWriter(request.GetRequestStream()))
    {
        writer.Write(content);
    }
    request.ContentLength = content.Length;
    using (var response = (HttpWebResponse)request.GetResponse())
    {
        var encoding = Encoding.GetEncoding(response.CharacterSet);
        using (var responseStream = response.GetResponseStream())
        {
            using (var reader = new StreamReader(responseStream, encoding))
            {
                return reader.ReadToEnd();
            }
        }
    }
