    string[] wbslist = File.ReadAllLines(filePath);
    foreach(string line in wbslist)
    {
        string [] splittedLine = line.Split('|');
        // I assume you need the second element in the delimited line
        if(string.Equals(splittedLine[1], TxtWBS.Text, StringComparison.OrdinalIgnoreCase))
            Console.WriteLine("Website found");
    }
