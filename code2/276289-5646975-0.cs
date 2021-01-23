    static bool OrganisationsNummer(string nr)
    {
        Regex rg = new Regex(@"^(\d{1})(\d{5})\-(\d{4})$");
        Match matches = rg.Match(nr);
    
        if (!matches.Success)
            return false;
    
        string group = matches.Groups[1].Value;
        string controlDigits = matches.Groups[3].Value;
        string allDigits = group + matches.Groups[2].Value + controlDigits;
    
        if (Int32.Parse(allDigits.Substring(2, 1)) < 2)
            return false;
    
        string nn = "";
    
        for (int n = 0; n < allDigits.Length; n++)
        {
            nn += ((((n + 1) % 2) + 1) * Int32.Parse(allDigits.Substring(n, 1)));
        }
    
        int checkSum = 0;
    
        for (int n = 0; n < nn.Length; n++)
        {
            checkSum += Int32.Parse(nn.Substring(n, 1));
        }
    
        return checkSum % 10 == 0 ? true : false;
    }
