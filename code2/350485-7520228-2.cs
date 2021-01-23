    string url = "https://accounts.google.com/o/oauth2/token";
    
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.ToString());
    request.Method = HttpMethod.POST.ToString();
    request.ContentType = "application/x-www-form-urlencoded";
    
    // You mus do the POST request before getting any response
    UTF8Encoding utfenc = new UTF8Encoding();
    byte[] bytes = utfenc.GetBytes(parameters); // parameters="code=...&client_id=...";
    Stream os = null;
    try // send the post
    {
        webRequest.ContentLength = bytes.Length; // Count bytes to send
        os = webRequest.GetRequestStream();
        os.Write(bytes, 0, bytes.Length);        // Send it
    }
    try
    {
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            // Do stuff ...
