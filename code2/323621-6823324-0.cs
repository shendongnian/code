    string[] lines = File.ReadAllLines(path);
    for (int i = 0; i < lines.Length; ++i)
    {
        lines[i] = lines[i].Substring(0, 43);
    }
