    public bool Check(string Name)
    {
        //try dns resolution, if fails, quit reporting error
        IPAddress[] addresses = null;
        try
        {
            addresses = Dns.GetHostAddresses(Name);
        }
        catch (SocketException)
        {
            return false;
        }
        //ping remote address
        PingReply reply = ping.Send(addresses[0]);
        switch (reply.Status)
        {
            case IPStatus.Success:
                return true;
                break;
            default:
                return false;
                break;
        }
    }
