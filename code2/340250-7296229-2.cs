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
    
            // load content from request.Url adding any headers etc
            // write it to response.OutputStream
            byte[] buffer = Encoding.UTF8.GetBytes("hello world");
            response.ContentLength64 = buffer.Length;
    
            using (Stream outputStream = response.OutputStream)
            {
                outputStream.Write(buffer, 0, buffer.Length);
            }
        }
    }
