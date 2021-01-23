    StreamReader sr = null;
    while(!sr.EndOfStream)
    {
        string line = sr.ReadLine();
        if (string.IsNullOrEmpty(line) || line.StartsWith(";")) continue;
        string[] tokens = line.Split("= ".ToCharArray(), 
                                     StringSplitOptions.RemoveEmptyEntries);
        if(tokens.Length == 2)
        {
            if("Yes".Equals(tokens[1], StringComparison.CurrentCultureIgnoreCase) ||
                "No" .Equals(tokens[1], StringComparison.CurrentCultureIgnoreCase))
            {
                // boolean
            }
            else
            {
                // non boolean
            }
        }
    }
