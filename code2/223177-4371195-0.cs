    public void SampleRegexUsage()
    {
        string regex = @"\d{2}/\d{2}/\d{4}";
        RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.Multiline;
        string input = @"Hello World.  Random date1 is 12/10/2010. Now 4 days later is 12/14/2010.";
    
        MatchCollection matches = Regex.Matches(input, regex, options);
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
    
            Console.WriteLine(":" + match.Groups[""].Value);
    
        }
    }
