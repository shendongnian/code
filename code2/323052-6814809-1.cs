        //-------------- Get Auth Token -------------------
        WebClient webClient = new WebClient();
        NameValueCollection data = new NameValueCollection();
        data.Add("accountType", "GOOGLE");
        data.Add("Email", "xxxx@gmail.com");
        data.Add("Passwd", "xxxx");//Passwd, not a misspell.
        data.Add("service", "analytics");
        data.Add("source", "xxxx-xxxx-xx");//Could be anything.
        byte[] bytes = webClient.UploadValues("https://www.google.com/accounts/ClientLogin", "POST", data);
        string tokens = Encoding.UTF8.GetString(bytes);
        string authToken = extractAuthToken(tokens);
        //-------------- Get page views -------------------
        string feed = "https://www.google.com/analytics/feeds/data";
        //Required:
        string ids = "ga:xxxx";
        string metrics = "ga:pageviews";
        string startDate = "2011-06-25";
        string endDate = "2011-07-25";
        //Optional:
        string dimensions = "ga:pagePath";
        string sort = "-ga:pageviews";            
        string feedUrl = string.Format("{0}?ids={1}&dimensions={2}&metrics={3}&sort={4}&start-date={5}&end-date={6}",
            feed, ids, dimensions, metrics, sort, startDate, endDate);
        webClient.Headers.Add("Authorization", "GoogleLogin " + authToken);
        string result = webClient.DownloadString(feedUrl);
        //-------------- Extract data from xml -------------------
        XDocument xml = XDocument.Parse(result);
        var ns1 = "{http://www.w3.org/2005/Atom}";
        var ns2 = "{http://schemas.google.com/analytics/2009}";
        var q = from entry in xml.Descendants()
                where entry.Name == ns1 + "entry"
                select new
                {
                    PagePath = entry.Element(ns2 + "dimension").Attribute("value").Value,
                    Views = entry.Element(ns2 + "metric").Attribute("value").Value
                };
        //-------------- Do something with data -------------------
        foreach (var page in q)
        {
            Debug.WriteLine(page.PagePath + " " + page.Views);                
        }
        //-------------- Help Method -------------------
        private string extractAuthToken(string data)
        {
            string authToken = null;
            var tokens = data.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var token in tokens)
            {
                if (token.StartsWith("Auth="))
                    authToken = token;
            }
    
            return authToken;
        }
 
