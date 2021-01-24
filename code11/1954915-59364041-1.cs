    static void Main(string[] args)
    {
        Console.WriteLine("Enter the ip address to update:");
        var ip = Console.ReadLine();
        if (!IsValidIPv4Address(ip))
            throw new ArgumentException("Invalid ip address: " + ip);
    
        var path = Directory.EnumerateFiles(@"C:\Program Files (x86)\Stuff\Noodles", "*.config", SearchOption.AllDirectories);
        foreach (var xmlfile in path)
        {
            var doc = XDocument.Load(xmlfile);
            var endpointsToUpdate = doc
                .Descendants("endpoint")
                .Where(x => new Uri((string)x.Attribute("address")).Host != "localhost")
                .ToArray();
    
            // skip if there is nothing to update
            if (!endpointsToUpdate.Any()) return;
    
            foreach (var endpoint in endpointsToUpdate)
            {
                string address = (string)endpoint.Attribute("address");
                string pattern = "//[^:]+";
                address = Regex.Replace(address, pattern, "//" + GetIPAddress(Dns.GetHostName()));
    
                endpoint.Attribute("address").SetValue(address);
            }
    
            doc.Save(xmlfile);
        }
    }
    
    bool IsValidIPv4Address(string text)
    {
        return text?.Split('.') is string[] parts &&
            parts.Length == 4 &&
            parts.All(x => byte.TryParse(x, out _));
    }
