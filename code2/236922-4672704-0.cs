    class TestHttp
    {
        static void Main()
        {
            using (HttpServer srvr = new HttpServer(5))
            {
                srvr.Start(8085);
                Console.WriteLine("Press [Enter] to quit.");
                Console.ReadLine();
            }
        }
    }
    class HttpServer : IDisposable
    {
        private readonly int _maxThreads;
        private readonly HttpListener _listener;
        private readonly Thread _listenerThread;
        private readonly ManualResetEvent _stop, _idle;
        private readonly Semaphore _busy;
        public HttpServer(int maxThreads)
        {
            _maxThreads = maxThreads;
            _stop = new ManualResetEvent(false);
            _idle = new ManualResetEvent(false);
            _busy = new Semaphore(maxThreads, maxThreads);
            _listener = new HttpListener();
            _listenerThread = new Thread(HandleRequests);
        }
        public void Start(int port)
        {
            _listener.Prefixes.Add(String.Format(@"http://+:{0}/", port));
            _listener.Start();
            _listenerThread.Start();
        }
        public void Dispose()
        { Stop(); }
        public void Stop()
        {
            _stop.Set();
            _listenerThread.Join();
            _idle.Reset();
            //aquire and release the semaphore to see if anyone is running, wait for idle if they are.
            _busy.WaitOne();
            if(_maxThreads != 1 + _busy.Release())
                _idle.WaitOne();
            _listener.Stop();
        }
        private void HandleRequests()
        {
            while (_listener.IsListening)
            {
                var context = _listener.BeginGetContext(ListenerCallback, null);
                if (0 == WaitHandle.WaitAny(new[] { _stop, context.AsyncWaitHandle }))
                    return;
            }
        }
        private void ListenerCallback(IAsyncResult ar)
        {
            _busy.WaitOne();
            try
            {
                HttpListenerContext context;
                try
                { context = _listener.EndGetContext(ar); }
                catch (HttpListenerException)
                { return; }
                if (_stop.WaitOne(0, false))
                    return;
                Console.WriteLine("{0} {1}", context.Request.HttpMethod, context.Request.RawUrl);
                context.Response.SendChunked = true;
                using (TextWriter tw = new StreamWriter(context.Response.OutputStream))
                {
                    tw.WriteLine("<html><body><h1>Hello World</h1>");
                    for (int i = 0; i < 5; i++)
                    {
                        tw.WriteLine("<p>{0} @ {1}</p>", i, DateTime.Now);
                        tw.Flush();
                        Thread.Sleep(1000);
                    }
                    tw.WriteLine("</body></html>");
                }
            }
            finally
            {
                if (_maxThreads == 1 + _busy.Release())
                    _idle.Set();
            }
        }
    }
