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
            //either this will work...
            servicePoint.ConnectionLeaseTimeout = 0;
            
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            //or this will (I hope)
            req.KeepAlive = false;
            return req;
        }
        private IPEndPoint Bind(ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount)
        {
            IPAddress address = IPAddress.Parse(this.IP);
            return new IPEndPoint(address, 0);
        }
    }
