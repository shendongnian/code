    private class CookieAwareWebClient : WebClient
    {
        public CookieAwareWebClient(CookieContainer c)
        {
            m_container = c;
        }
        private CookieContainer m_container;
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = m_container;
            }
            return request;
        }
    }
