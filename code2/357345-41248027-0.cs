    private static string ExtractCN(string distinguishedName)
    {
        // CN=...,OU=...,OU=...,DC=...,DC=...
        string[] parts;
    
        parts = distinguishedName.Split(new[] { ",DC=" }, StringSplitOptions.None);
        var dc = parts.Skip(1);
    
        parts = parts[0].Split(new[] { ",OU=" }, StringSplitOptions.None);
        var ou = parts.Skip(1);
    
        parts = parts[0].Split(new[] { ",CN=" }, StringSplitOptions.None);
        var cnMulti = parts.Skip(1);
    
        var cn = parts[0];
    
        if (!Regex.IsMatch(cn, "^CN="))
            throw new CustomException(string.Format("Unable to parse distinguishedName for commonName ({0})", distinguishedName));
    
        return Regex.Replace(cn, "^CN=", string.Empty);
    }
