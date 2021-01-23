    public static string netsh(String IPv6)
    {
        IPAddress wanted;
        if (!IPAddress.TryParse(IPv6, out wanted))
            throw new ArgumentException("Can't parse as an IPAddress", "IPv6");
    
        Regex re = new Regex("^([0-9A-F]\S+)\s+(\S+)\s+(\S+)", RegexOptions.IgnoreCase);
        // ... the code that runs netsh and gathers the output.
            Match m = re.Match(output);
            if (m.Success)
            {
                // [0] is the entire line
                // [1] is the IP Address string
                // [2] is the MAC Address string
                // [3] is the status (Permanent, Stale, ...)
                //
                IPAddress found;
                if (IPAddress.TryParse(m.Groups[1].Value, out found))
                {
                     if(wanted.Equals(found))
                     {
                          return m.Groups[2].Value;
                     }
                }
            }
        // ... the code that finishes the loop on netsh output and returns failure
    }
