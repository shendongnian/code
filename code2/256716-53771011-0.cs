    private bool HostExists(string PCName)
    {
        Ping pinger = new Ping();
        try
        {
            PingReply reply = pinger.Send(PCName);
            return reply.Status == IPStatus.Success;
        }
        finally
        {
            pinger.Dispose();
        }
        return false;
    }
