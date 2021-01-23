    byte[] buffer = Encoding.ASCII.GetBytes (new string('a', 32));
    var options = new PingOptions (32, true);
    foreach (Game curgame in GameList.ToArray())
    {
        Ping p = new Ping();
        p.PingCompleted += p_PingCompleted;
        // e.UserState will be curgame
        p.SendAsync(IPAddress.Parse(curgame.IP), 2500, buffer, options, curgame);
    }
