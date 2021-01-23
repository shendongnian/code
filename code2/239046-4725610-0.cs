    string inputFile; // = ...
    string outputFile; // = ...
    HashSet<string> keys = new HashSet<string>();
    using (StreamReader reader = new StreamReader(inputFile))
    using (StreamWriter writer = new StreamWriter(outputFile))
    {
        string line = reader.ReadLine();
        while (line != null)
        {
            string candidate = line.Split('|')[0];
            if (keys.Add(candidate))
                writer.WriteLine(line);
            line = reader.ReadLine();
        } 
    }
