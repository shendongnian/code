    string[] inputs = { "Thing1 Thing2 S1", "Thing1 Thing2 2006-07 Series 6", "Thing1 Thing2 2006-2007 S12 RP", "Thing1 Thing2 2020-21 S6", "Thing1 Thing2 2022-2024 S12", "Thing1 Thing2 2024 Onwards" };
    string pattern = @"\b(?<Year1>\d{4})(-(?<Year2>\d{2,4}))?\b";
    Regex rx = new Regex(pattern);
    
    foreach (var input in inputs)
    {
        Match m = rx.Match(input);
        Console.WriteLine("{0}: {1}", m.Success, input);
        if (m.Success)
        {
            string year1 = m.Groups["Year1"].Value;
            string year2 = m.Groups["Year2"].Value;
            Console.WriteLine("Year1: {0}, Year2: {1}", year1, year2 == "" ? "N/A" : year2);
        }
        Console.WriteLine();
    }
