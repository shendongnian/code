        string url = String.Format("http://example.com");
        CredentialCache credentialCache = new CredentialCache();
        credentialCache.Add(new Uri(url), "Basic", new NetworkCredential("testing", "123456"));
        HttpWebRequest requestObj = (HttpWebRequest)WebRequest.Create(url);
        requestObj.Method = "Get";
        requestObj.Credentials = **credentialCache**;
        HttpWebResponse responseObj = null;
        responseObj = (HttpWebResponse)requestObj.GetResponse();
        string strresult = null;
        using (Stream stream = responseObj.GetResponseStream())
        {
            StreamReader sr = new StreamReader(stream);
            strresult = sr.ReadToEnd();
            sr.Close();
        }
