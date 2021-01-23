    public static bool IsIPv4(string value)
    {
        var octets = value.Split('.');
        // if we do not have 4 octets, return false
        if (octets.Length!=4) return false;
        // for each octet
        foreach(var octet in octets) 
        {
            int q;
            // if parse fails 
            // or length of parsed int != length of octet string (i.e.; '1' vs '001')
            // or parsed int < 0
            // or parsed int > 255
            // return false
            if (!Int32.TryParse(octet, out q) 
                || !q.ToString().Length.Equals(octet.Length) 
                || q < 0 
                || q > 255) { return false; }
        }
        return true;
    }
