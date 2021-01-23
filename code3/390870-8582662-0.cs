    public string ConvertToHex(string asciiString)
    { 
        var newasciiString = Substring(asciiString,0,2);
        string hex = "";
        foreach (char c in newasciiString)
        {
            int tmp = c;
            hex += String.Format("{0:x2}", (uint)System.Convert.ToUInt32(tmp.ToString()));
        }
        return hex;
    } 
