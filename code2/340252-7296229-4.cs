    public class MyProxy
    {
        private readonly HttpListener listener;
    
        public MyProxy()
        {
            listener = new HttpListener();
        }
    
        public void Start()
        {
            listener.Prefixes.Add("http://*:8888/");
            listener.Prefixes.Add("https://*:8889/");
            listener.Start();
            Console.WriteLine("Proxy started, hit enter to stop");
            listener.BeginGetContext(GetContextCallback, null);
            Console.ReadLine();
            listener.Stop();
        }
    
        public void GetContextCallback(IAsyncResult result)
        {
            var context = listener.EndGetContext(result);
            listener.BeginGetContext(GetContextCallback, null);
    
            var request = context.Request;
            var response = context.Response;
            var url = request.Url;
            UriBuilder builder = new UriBuilder(url);
            builder.Port = url.Port == 8888 ? 80 : 443;
            url = builder.Uri;
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Proxy = GlobalProxySelection.GetEmptyWebProxy();
            WebResponse webResponse = webRequest.GetResponse();
            using (Stream reader = webResponse.GetResponseStream())
            {
                using (Stream writer = response.OutputStream)
                {
                    reader.CopyTo(writer);
                }
            }
        }
    }
