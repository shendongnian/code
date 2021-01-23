    public string SendPost(string url, string postData)
    {
        string webpageContent = string.Empty;
    
        try
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
    
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = byteArray.Length;
    
            using (Stream webpageStream = webRequest.GetRequestStream())
            {
                webpageStream.Write(byteArray, 0, byteArray.Length);
            }
    
            using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    webpageContent = reader.ReadToEnd();
                }
            }
        }
        catch (Exception ex)
        {
            //throw or return an appropriate response/exception
        }
    
        return webpageContent;
    }
