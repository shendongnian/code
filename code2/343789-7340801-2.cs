    string line = "your line to append";
    // Read existing lines into list
    List<string> existItems = new List<string>();
        using (StreamReader sr = new StreamReader(path))
            while (!sr.EndOfStream)
                existItems.Add(sr.ReadLine());
    // Conditional write new line to file
    if (existItems.Contains(line))
        using (StreamWriter sw = new StreamWriter(path))
            sw.WriteLine(line);
