        private string FetchHTML(string sUrl, Encoding encoding)
        {
            System.Net.WebClient oClient = new System.Net.WebClient();
            oClient.Encoding = encoding;
            // set the user agent to IE6
            oClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.0.3705;)");
            return System.Web.HttpUtility.HtmlDecode(oClient.DownloadString(sUrl));
        }
