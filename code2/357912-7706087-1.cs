    // Build postData
    StringBuilder post = new StringBuilder();
    foreach(item in dictionary) {
      post.AppendFormat("&{0}={1}", item.key, HttpUtility.UrlEncode(item.value));
    }
    string postData = post.ToString();
    
    // HTTP POST
    Uri uri = new Uri(url);
    request = (HttpWebRequest) WebRequest.Create(uri);
    request.Method = "POST";
    request.ContentType = "application/x-www-form-urlencoded";
    request.ContentLength = postData.Length;
    using(Stream writeStream = request.GetRequestStream())
    {
      UTF8Encoding encoding = new UTF8Encoding();
      byte[] bytes = encoding.GetBytes(postData);
      writeStream.Write(bytes, 0, bytes.Length);
    }
