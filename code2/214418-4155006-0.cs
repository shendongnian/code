    public class Example    
    {
        private HttpListener _listener;
        public void StartTutorial()
        {
            _listener = HttpListener.Create(IPAddress.Any, 8081);
            _listener.RequestReceived += OnRequest;
            _listener.Start(5);
        }
        private void OnRequest(object source, RequestEventArgs args)
        {
            IHttpClientContext context = (IHttpClientContext)source;
            IHttpRequest request = args.Request;
            IHttpResponse response = request.CreateResponse(context);
            response.Body = new FileStream("Path\\to\\file.jpg");
            response.ContentType = "image\jpeg";
            response.Send();
        }
    }
