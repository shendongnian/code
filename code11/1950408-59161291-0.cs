        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
            public void SearchResult()
        {
            //Run a Google Search
            string uriString = "http://www.google.com/search";
            string keywordString = "Search String";
            WebClient webClient = new WebClient();
            NameValueCollection nameValueCollection = new NameValueCollection();
            nameValueCollection.Add("q", keywordString);
            webClient.QueryString.Add(nameValueCollection);
            
            string result = webClient.DownloadString(uriString);
            string search = getBetween(result, "Address", "Hours");
            rtbHtml.Text = getBetween(search, "\">", "<"); 
        } 
