        private static void ScanSites(ArrayList sites)
        {
            var handles = new List<WaitHandle>();
            foreach (string uriString in sites)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriString);
                    request.Method = "GET";
                    request.Proxy = null;
                    RequestState state = new RequestState();
                    state.Request = request;
                    IAsyncResult result = request.BeginGetResponse(new AsyncCallback(ResponseCallback), state);
                    handles.Add(result.AsyncWaitHandle);
                    // Timeout comes here
                    ThreadPool.RegisterWaitForSingleObject(result.AsyncWaitHandle,
                        new WaitOrTimerCallback(TimeOutCallback), request, 100, true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Bad URL");
                    Interlocked.Increment(ref _count);
                }
            }
            WaitHandle.WaitAll(handles.ToArray());
        }
