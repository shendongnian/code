        private static void ScanSites(ArrayList sites)
        {
            var semaphore = new Semaphore(0,sites.Count);
            foreach (string uriString in sites)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriString);
                    request.Method = "GET";
                    request.Proxy = null;
                    RequestState state = new RequestState();
                    state.Request = request;
                    state.Semaphore = semaphore;
                    IAsyncResult result = request.BeginGetResponse(new AsyncCallback(ResponseCallback), state);
                    // Timeout comes here
                    ThreadPool.RegisterWaitForSingleObject(result.AsyncWaitHandle,
                        (o, timeout => { TimeOutCallback }, request, 100, true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Bad URL");
                    Interlocked.Increment(ref _count);
                }
            }
         for(var i =0; i <sites.Count; i++) semaphore.WaitOne();
     }
     static void ReadCallback(IAsyncResult result)
     {
         try
             { ... }
         finally{
             var state = result.State as RequestState;
             if (state != null) state.Semaphore.Release();
         }
     }
