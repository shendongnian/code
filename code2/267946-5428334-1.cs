    foreach (string hostName in hostNames)
    {
        //string hostName = Dns.GetHostName();
        IPHostEntry entry = Dns.GetHostEntry(hostName);
        Console.WriteLine(entry.HostName); // output name of web host
        IPAddress[] addresses = entry.AddressList; // get list of IP addresses
        foreach (var address in addresses)
        {
            Console.WriteLine(address);
        }
    }
