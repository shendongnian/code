        string fileName = "Text.txt";
        List<string> lines = new List<string>();
        using (StreamReader r = new StreamReader(fileName))
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                lines.Add(line);
            }
        }
        foreach (string s in lines)
        {
            Console.WriteLine(s);
           //can do your Regex here
        }
