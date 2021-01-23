    static void GetGoogleWebHistory(int month, int day, int yr, string UserName, string Pass)
    {
        string iURL = "http://www.google.com/history/lookup?month=" + month + "&day=" + day + "&yr=" + yr + "&output=rss";
        WebClient client = new WebClient();
        GDataCredentials gdc = new GDataCredentials(UserName, Pass);
        RequestSettings rs = new RequestSettings(Guid.NewGuid().ToString(), gdc);
        XmlDocument XDoc = new XmlDocument();
        XDoc.LoadXml(client.DownloadString(iURL));
    }
