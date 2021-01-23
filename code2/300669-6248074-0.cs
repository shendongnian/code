    var unsortedIps =
        new[]
        {
            "192.168.1.4",
            "192.168.1.5",
            "192.168.2.1",
            "10.152.16.23",
            "69.52.220.44"
        };
    var sortedIps = unsortedIps
        .Select(Version.Parse)
        .OrderBy(arg => arg)
        .Select(arg => arg.ToString())
        .ToList();
