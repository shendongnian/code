    public class HttpRequestHandler {
        private CookieContainer cookies;
        public HttpRequestHandler() {
            cookies = new CookieContainer();
        }
        public HttpWebRequest GenerateWebRequest(string url) {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new System.Uri(url));
            request.CookieContainer = cookies;
            request.AllowAutoRedirect = true;
            request.KeepAlive = true;
            request.Referer = HttpUtility.UrlEncode(referer);
            request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.0.8) Gecko/2009021910 Firefox/3.0.7 (.NET CLR 3.5.30729)";
            request.Headers.Add("Pragma", "no-cache");
            request.Timeout = 40000;
            return request;
        }
    }
