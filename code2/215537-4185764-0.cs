    private class CookieAwareWebClient : WebClient
    {
        public CookieAwareWebClient()
        {
            CookieContainer = new CookieContainer();
        }
        public CookieContainer CookieContainer { get; private set; }
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            var httpRequest = request as HttpWebRequest;
            if (httpRequest != null)
            {
                httpRequest.CookieContainer = CookieContainer;
            }
            return request;
        }
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        using (var client = new CookieAwareWebClient())
        {
            client.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            client.DownloadData("http://www.google.com");
            var cookies = client.CookieContainer.GetCookies(new Uri("http://www.google.com"));
            var prefCookie = cookies["PREF"];
            webBrowser1.Navigate("http://www.google.com", "", null, "Cookie: " + prefCookie.Value + Environment.NewLine);
        }
    }
