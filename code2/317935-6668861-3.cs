    public static IEnumerable<string> GetIP4Addresses()
    {
        return Dns.GetHostAddresses(Dns.GetHostName())
            .Where(IPA => IPA.AddressFamily == AddressFamily.InterNetwork)
            .Select(x => x.ToString());
    }
