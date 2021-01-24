        static void Main(string[] args)
        {
            HttpWebRequest webRequest = CreateWebRequest();
            string cookie = null;
            HttpWebResponse webResponse;
            try
            {
                webResponse = (HttpWebResponse) webRequest.GetResponse();
            }
            catch (WebException ex)
            {
                var headers = (WebHeaderCollection)ex.Response.GetType().GetProperty("Headers").GetValue(ex.Response, null);
                cookie = headers.Get("Set-Cookie");
                webRequest = CreateWebRequest();
                webRequest.Headers.Add("Cookie", cookie);
                webResponse = (HttpWebResponse) webRequest.GetResponse();
            }
            string response = string.Empty;
            using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
            {
                response = sr.ReadToEnd();
                sr.Close();
            }
        }
        private static HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest;
            var myURI = "https://myURI";
            webRequest = (HttpWebRequest)WebRequest.Create(myURI);
            webRequest.Method = "GET";
            string myCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("myUsername" + ":" + "myPassword"));
            webRequest.Headers.Add("Authorization", "Basic " + myCredentials);
            return webRequest;
        }
