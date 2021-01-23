    using(WebClient oWebClient = new WebClient())
    {
        // use an event for waiting, rather than a Thread.Sleep() loop.
        var notifier = new AutoResetEvent(false);
    
        oWebClient.Encoding = System.Text.Encoding.UTF8;
        long lReceived = 0;
        long lTotal = 0;
        // Set up a delegate to watch download progress.
        oWebClient.DownloadProgressChanged += delegate(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine(e.ProgressPercentage + "% (" + e.BytesReceived / 1024f + "kb of " + e.TotalBytesToReceive / 1024f + "kb)");
            // Assign to outer variables to allow busy-wait to check.
            lReceived = e.BytesReceived;
            lTotal = e.TotalBytesToReceive;
    
            // Indicate that things are done
            if(lReceived >= lTotal) notifier.Set();
        };
        oWebClient.DownloadFileAsync(new Uri(sUrl + "?" + sPostData), sTempFile);
    
        // wait for signal to proceed
        notifier.WaitOne();
    }
