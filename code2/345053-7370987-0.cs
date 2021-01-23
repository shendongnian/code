    var regi = new Regex(@"MERCHANTNO:\s*([0-9]*)");
    string need = "105838015";
    bool found = false;
    
    using (StreamReader reader = new StreamReader("file.txt"))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            var match = regi.Match(line);
            if (match.Groups.Count == 2)
            {
                if (match.Groups[1].Value == need)
                {
                    found = true;
                    break;
                }
            }
        }
    }
    
    Console.WriteLine("Found: {0}", found);
