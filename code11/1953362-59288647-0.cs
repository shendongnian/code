        StreamReader sr = new StreamReader(@"N:\Desktop\krew.txt");
        Dictionary<string, string> dict = new Dictionary<string, string>();
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string[] wholeLine = line.Split('\t');
            dict.Add(wholeLine[0], wholeLine[1]);
        }
