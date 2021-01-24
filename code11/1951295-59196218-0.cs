    string s = "sampleText";
    string pattern = "[(]([0-9]*?)[)]$";
    for (int i = 0; i < 5; i++)
    {
        var m = Regex.Match(s, pattern);
        if (m.Success)
        {
            int value = int.Parse(m.Groups[1].Value);
            s = Regex.Replace(s, pattern, $"({++value})");
        }
        else
        {
            s += "(1)";
        }
        Console.WriteLine(s);
    }
