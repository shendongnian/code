    foreach(string hostName in s)
    {
        //string hostName = Dns.GetHostName();
        IPHostEntry IPHost = Dns.GetHostEntry(hostName);
        Console.WriteLine(IPHost.HostName); // Output name of web host
        IPAddress[] address = IPHost.AddressList; // get list of IP address
        // Console.WriteLine(&quot;List IP {0} :&quot;, IPHost.HostName);
        if (address.Length &gt; 0)
        {
            for (int i = 0; i &lt; address.Length; i++)
            {
                Console.WriteLine(address[i]);
            }
        }
    }
