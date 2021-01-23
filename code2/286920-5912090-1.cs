    string fqdn = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).HostName;
    int firstDot = fqdn.IndexOf('.');
    string host = fqdn.Substring(0, firstDot);
    string domain = fqdn.Substring(firstDot + 1);
    
    NTAccount account = new NTAccount(domain, host + "$");
    SecurityIdentifier sid =
        (SecurityIdentifier)account.Translate(typeof(SecurityIdentifier));
    // we're done, show the results:
    Console.WriteLine(account.Value);
    Console.WriteLine(sid.Value);
