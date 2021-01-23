    public static void SetRequest(string mXml)
    {
        HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.CreateHttp("http://dork.com/service");
        webRequest.Method = "POST";
        webRequest.Headers["SOURCE"] = "WinApp";
        // Decide your encoding here
        //webRequest.ContentType = "application/x-www-form-urlencoded";
        webRequest.ContentType = "text/xml; charset=utf-8";
    
        // You should setContentLength
        byte[] content = System.Text.Encoding.UTF8.GetBytes(mXml);
        webRequest.ContentLength = content.Length;
        var reqStream = await webRequest.GetRequestStreamAsync();
        reqStream.Write(content, 0, content.Length);
        var res = await httpRequest(webRequest);
}
