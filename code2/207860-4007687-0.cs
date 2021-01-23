    class Program
    {
        private static ManualResetEvent _waitHandle = new ManualResetEvent(false);
    
        static void Main()
        {
            NonblockingListener(new string[] { "http://+:5432/" });
        }
    
        public static void NonblockingListener(string[] prefixes)
        {
            using (var listener = new HttpListener())
            {
                foreach (string s in prefixes)
                {
                    listener.Prefixes.Add(s);
                }
                listener.Start();
                var result = listener.BeginGetContext(new AsyncCallback(ListenerCallback), listener);
                Console.WriteLine("Waiting for request to be processed asyncronously.");
                // Block here until the handle is Set in the callback
                _waitHandle.WaitOne();
                Console.WriteLine("Request processed asyncronously.");
                listener.Close();
            }
        }
    
        public static void ListenerCallback(IAsyncResult result)
        {
            var listener = (HttpListener)result.AsyncState;
            var context = listener.EndGetContext(result);
    
            var response = context.Response;
            string responseString = "<HTML><BODY>Hello World!</BODY></HTML>";
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            response.OutputStream.Write(buffer, 0, buffer.Length);
            // Finished sending the response, now set the wait handle
            _waitHandle.Set();
        }
    }
