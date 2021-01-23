    void DoPDFDownload(string strMyUrl, string strPostData, string saveLocation)
    {
        //create the request
        var wr = (HttpWebRequest)WebRequest.Create(myURL);
        wr.Method = "POST";
        wr.ContentLength = strPostData.Length;
        //Identify content type... strPostData should be url encoded per this next    
        //declaration
        wr.ContentType = "application/x-www-form-urlencoded";
        //just for good measure, set cookies if necessary for session management, etc.
        wr.CookieContainer = new CookieContainer();
        using(var sw = new StreamWriter(wr.GetRequestStream()))
        {
            sw.Write(strPostData);
        }
        var resp = wr.GetResponse();
        //feeling rather lazy at this point, but if you need further code for writing
        //response stream to a file stream, I can provide.
        //...
        
    }
