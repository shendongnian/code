    string csv = GetCSV();  // will load your CSV, or the above data
    foreach (string  line in csv.Split('\n'))
    {
        Console.WriteLine("--- Begin record ---");
        foreach (Match m in Regex.Matches(line, "\".+?\""))            
            Console.WriteLine(m.Value);            
    }
