     public static void GetFileWithCredentials(string userName, string password, string url)
    {
        using (WebClient wc = new WebClient())
        {
            wc.Credentials = new NetworkCredential(userName, password);
            string xml = wc.DownloadString(url);
            XmlDocument tournamentsXML = new XmlDocument();
            tournamentsXML.LoadXml(xml);
        }
    }
