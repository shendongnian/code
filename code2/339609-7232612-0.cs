    private static bool IsLanIP(IPAddress address)
    {
        var ping = new Ping();
        var rep = ping.Send(address, 100, new byte[] { 1 }, new PingOptions()
        {
            DontFragment = true,
            Ttl = 1
        });
        return rep.Status != IPStatus.TtlExpired && rep.Status != IPStatus.TimedOut && rep.Status != IPStatus.TimeExceeded;
    }
