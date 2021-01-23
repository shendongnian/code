    List<string> matchingLines = new List<string>();
    using (var reader = new StreamReader("data.csv"))
    {
        string rawline;
        while (null != (rawline = reader.ReadLine()))
        {
            if (rawline.TrimEnd().Split(',').Last() == "True") continue;
            
            matchingLines.Add(rawline);
        }
    }
