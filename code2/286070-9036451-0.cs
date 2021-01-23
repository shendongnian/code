    public class HttpListenerCallbackState
    {
        private readonly HttpListener _listener;
        private readonly AutoResetEvent _listenForNextRequest;
        public HttpListenerCallbackState(HttpListener listener)
        {
            if (listener == null) throw new ArgumentNullException("listener");
            _listener = listener;
            _listenForNextRequest = new AutoResetEvent(false);
        }
        public HttpListener Listener { get { return _listener; } }
        public AutoResetEvent ListenForNextRequest { get { return _listenForNextRequest; } }
    }
    public class HttpRequestHandler
    {
        private int requestCounter = 0;
        private ManualResetEvent stopEvent = new ManualResetEvent(false);
        public void ListenAsynchronously(IEnumerable<string> prefixes)
        {
            HttpListener listener = new HttpListener();
            foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
            }
            listener.Start();
            HttpListenerCallbackState state = new HttpListenerCallbackState(listener);
            ThreadPool.QueueUserWorkItem(Listen, state);
        }
        public void StopListening()
        {
            stopEvent.Set();
        }
        private void Listen(object state)
        {
            HttpListenerCallbackState callbackState = (HttpListenerCallbackState)state;
            while (callbackState.Listener.IsListening)
            {
                callbackState.Listener.BeginGetContext(new AsyncCallback(ListenerCallback), callbackState);
                int n = WaitHandle.WaitAny(new WaitHandle[] { callbackState.ListenForNextRequest, stopEvent});
                if (n == 1)
                {
                    // stopEvent was signalled 
                    callbackState.Listener.Stop();
                    break;
                }
            }
        }
        private void ListenerCallback(IAsyncResult ar)
        {
            HttpListenerCallbackState callbackState = (HttpListenerCallbackState)ar.AsyncState;
            HttpListenerContext context = null;
            int requestNumber = Interlocked.Increment(ref requestCounter);
            try
            {
                context = callbackState.Listener.EndGetContext(ar);
            }
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                callbackState.ListenForNextRequest.Set();
            }
            if (context == null) return;
            HttpListenerRequest request = context.Request;
            if (request.HasEntityBody)
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(request.InputStream, request.ContentEncoding))
                {
                    string requestData = sr.ReadToEnd();
                    //Stuff I do with the request happens here  
                }
            }
            try
            {
                using (HttpListenerResponse response = context.Response)
                {
                    //response stuff happens here  
                    string responseString = "Ok";
                    byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.LongLength;
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                    response.Close();
                }
            }
            catch (Exception e)
            {
            }
        }
    }
