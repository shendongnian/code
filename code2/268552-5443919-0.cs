    class Program
    {
        static ManualResetEvent _manualReset = new ManualResetEvent(false);
        static void Main()
        {
            WebClient client = new WebClient();
            Uri uri = new Uri("http://www.google.com");
    
            client.DownloadProgressChanged += (_sender, _e) =>
            {
                //
            };
    
            client.DownloadStringCompleted += (_sender, _e) => 
            {
                if (_e.Error == null)
                {
                    // do something with the results
                    Console.WriteLine(_e.Result);
                }
                // signal the event
                _manualReset.Set();
            };
    
            // start the asynchronous operation
            client.DownloadStringAsync(uri);
    
            // block the main thread until the event is signaled
            // or until 30 seconds have passed and then unblock
            if (!_manualReset.WaitOne(TimeSpan.FromSeconds(30)))
            {
                // timed out ...
            }
        }
    }
