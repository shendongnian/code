    private bool HostExists(string PCName)
    {
        Ping pinger = new Ping();
        try
        {
            PingReply reply = pinger.Send(PCName);
            return reply.Status == IPStatus.Success;
        }
        catch
        {
            return false;
        }
        finally
        {
            pinger.Dispose();
        }
    }
