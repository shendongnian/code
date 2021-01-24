    IPAddress addressToPing = Dns.GetHostAddresses("example.com")
        .First(address => address.AddressFamily == AddressFamily.InterNetwork);
    using (Ping ping = new Ping())
    {
        PingReply reply = ping.Send(addressToPing, 10000, new byte[] { 1 }, new PingOptions(1, true));
        // Do something with reply...
    }
