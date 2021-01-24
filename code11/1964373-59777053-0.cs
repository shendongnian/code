    const string rawLine = "\"TeamName\",\"PlayerName\",\"Position\"  \"Chargers\",\"Philip Rivers\",\"QB\"  \"Colts\",\"Peyton Manning\",\"QB\"  \"Patriots\",\"Tom Brady\",\"QB\"";                       
    var matches = new Regex(@"(\""(.*?)[^,]"")").Matches(rawLine).Cast<Match>().ToList();
    // loop through our matches
    for(int i = 0; i < matches.Count; i++)
    {                
        // join our records we need to output
        string str = string.Join(",", matches.Skip(i * 3).Take(3));
        if(!string.IsNullOrEmpty(str))
             Console.WriteLine(str);
    }            
    Console.WriteLine("Press [ENTER] to exit.");
    Console.ReadLine();
