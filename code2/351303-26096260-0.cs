    if (!NetworkInterface.GetIsNetworkAvailable())
    {
        // Network does not available.
        return;
    }
    
    Uri uri = new Uri("http://stackoverflow.com/any-uri");
    
    Ping ping = new Ping();
    PingReply pingReply = ping.Send(uri.Host);
    if (pingReply.Status != IPStatus.Success)
    {
        // Website does not available.
        return;
    }
