    timer.Tick += new EventHandler(delegate(object p, EventArgs a)
    {
        // Disable the timer so there won't be another tick causing an overlapped request
        timer.IsEnabled = false;
        client.DownloadStringAsync(new Uri(url));                     
    });
    client.DownloadStringCompleted += (s, ea) =>
    {
        // Re-enable the timer
        timer.IsEnabled = true;
        //Do something                
    };
