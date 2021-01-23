    public System.Net.IWebProxy RequestClass(String proxyURL, int port, String username, String password)
        {
            //Validate proxy address
            var proxyURI = new Uri(string.Format("{0}:{1}", proxyURL, port));
            //Set credentials
            ICredentials credentials = new NetworkCredential(username, password);
            //Set proxy
           return new WebProxy(proxyURI, true, null, credentials);
        }
