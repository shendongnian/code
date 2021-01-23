    var lines = File.ReadAllLines("filename").ToList(); // Read all lines and cast it to a List<string>
    var matches = lines.Where(x => x == "query");
    foerach(var match in matches)
    {
        Console.WriteLine(match);
    }
