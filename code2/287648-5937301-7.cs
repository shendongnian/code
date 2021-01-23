    foreach (string item in results)
    {
        List<string> tokens = new List<string>();
        // split at &
        foreach (string t in item.Split('&'))
        {
            // trim spaces
            string token = t.Trim();
            // ignore empty tokens
            if (token == "")
                continue;
            tokens.Add(t);
        }
        // print tokens, separated by tabs
        foreach (string t in tokens)
            Console.Write("{0}\t", t);
        
        Console.WriteLine();
        Console.WriteLine();
    }
