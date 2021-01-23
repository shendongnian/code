    public class WebClient2 : WebClient
    {
        public WebClient2(IPAddress ipAddress) {
            _ipAddress = ipAddress;
        }
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = (WebRequest)base.GetWebRequest(address);
            ((HttpWebRequest)request).ServicePoint.BindIPEndPointDelegate += (servicePoint, remoteEndPoint, retryCount) => {
                return new IPEndPoint(_ipAddress, 0);
            };
            return request;
        }
    }
