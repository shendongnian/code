    foreach (string file in Directory.GetFiles(path, "*.txt"))
    {
        string[] lines = System.IO.File.ReadAllLines(file);
        foreach (string line in lines)
        {
            process(line);
        }
    }
