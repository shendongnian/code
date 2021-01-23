    #region Function to get x-rate via proxy
    public string fncProxyGetRate(string countryCode)// use 'GBP' for British Pounds
    {
        string rtnTxt = "";
        try
        {
            string url = "http://rss.timegenie.com/forex.xml";
            string proxyUrl = "http://xxx.xxx.x.x:8080/";
            string myXratePath = "/forex/data/code[text()='" + countryCode + "']";
            WebProxy wp = new WebProxy(proxyUrl, true);
            wp.Credentials = CredentialCache.DefaultCredentials;
            WebClient wc = new WebClient();
            wc.Proxy = wp;
            MemoryStream ms = new MemoryStream(wc.DownloadData(url));
            XmlTextReader rdr = new XmlTextReader(ms);
            XmlDocument doc = new XmlDocument();
            doc.Load(rdr);
            rtnTxt = doc.SelectSingleNode(myXratePath).ParentNode.SelectSingleNode("rate").InnerXml;
        }
        catch (Exception ex)
        {
            rtnTxt = ex.Message;
        }
        return rtnTxt;
    } 
    #endregion
