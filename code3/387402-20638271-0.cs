    static void Test()
    {                       
        var allLines = File.ReadAllLines("test.txt");
        int controller = 0;
        var buffer = new List<string[]>();
        foreach (string line in allLines)
        {
            string path = (controller == 0) 
                ? "bag1.txt" : (controller == 1) 
                                 ? "bag2.txt" : "bag3.txt";
            buffer.Add(new string[] { path, line });
            if (line == "EOS") { controller++; }
        }
        var fileNames = (from b in buffer select b[0]).Distinct();
        foreach (string file in fileNames)
        {
            File.WriteAllLines(file, (from b in buffer where b[0] == file select b[1]).ToArray());
        }
    }
