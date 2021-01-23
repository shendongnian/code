    public class WebClientEx : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = (HttpWebRequest)base.GetWebRequest(address);
            request.AllowAutoRedirect = false;
            return request;
        }
    }
