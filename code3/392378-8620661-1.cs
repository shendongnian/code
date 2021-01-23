    List<string> chars = new List<string>();
    foreach (string line in assignment_lines)
    {
        chars.AddRange(line.Split('='));
    }
    string[] strArray = chars.ToArray();
