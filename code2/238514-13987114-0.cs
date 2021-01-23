    private string GetPageSource(string url)
        {
            string htmlSource = string.Empty;
            try
            {
                WebProxy myProxy = new WebProxy("ProxyAdress", 8080);
                using (WebClient client = new WebClient())
                {
                    client.Proxy = myProxy;
                    client.Proxy.Credentials = new NetworkCredential("Username", "Password");
                    htmlSource = client.DownloadString(url);
                }
            }
            catch (WebException ex)
            {
                // log any exceptions
            }
            return htmlSource;
        }
