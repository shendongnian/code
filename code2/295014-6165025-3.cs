    public class UseIP
    {
        public string IP { get; private set; }
        public UseIP(string IP)
        {
            this.IP = IP;
        }
        public HttpWebRequest CreateWebRequest(Uri uri)
        {
            ServicePoint servicePoint = ServicePointManager.FindServicePoint(uri);
            servicePoint.BindIPEndPointDelegate = new BindIPEndPoint(Bind);
            //Will cause bind to be called periodically
            servicePoint.ConnectionLeaseTimeout = 0;
            
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            //will cause bind to be called for each request (as long as the consumer of the request doesn't set it back to true!
            req.KeepAlive = false;
            return req;
        }
        private IPEndPoint Bind(ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount)
        {
            IPAddress address = IPAddress.Parse(this.IP);
            return new IPEndPoint(address, 0);
        }
    }
