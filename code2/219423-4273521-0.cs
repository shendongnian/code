    public static IPEndPoint BindIPEndPointCallback(ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount)
    {
        Console.WriteLine("BindIPEndpoint called");
          return new IPEndPoint(IPAddress.Any,5000);
    }
    public static void Main()
    {
        HttpWebRequest request = (HttpWebRequest) WebRequest.Create("http://MyServer");
        request.ServicePoint.BindIPEndPointDelegate = new BindIPEndPoint(BindIPEndPointCallback);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    }
