    // string input = "<your input>";
    Match m = Regex.Match(input, @"\s*(?<dec>\d+)\s*=");
    List<int> intList = new List<int>();
        
    while (m.Success)
    {
        intList.Add(Int32.Parse(m.Groups["dec"].Value));
        m = m.NextMatch();
    }
    // Process intList
