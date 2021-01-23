    try
    {
        System.Net.NetworkInformation.Ping ping = new Ping();
        PingReply result = ping.Send("www.google.com");
        if (result.Status == IPStatus.Success)
            return true;
         return false;
    }
    catch
    {
        return false;
    }
