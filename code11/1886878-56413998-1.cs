    var commands = new List<string>();
    
    using (var sr = new StreamReader("PATH TO FILE"))
    {
        var line = sr.ReadLine();
    
        while (line != null)
        {
            if (line.ToLower().StartsWith("start "))
            {
                commands.Add(line);
            }
    
            line = sr.ReadLine();
        }
    }
