    string s = "hello world; some random text; foo;";
    Regex r = new Regex(".+?;");
    for (Match m = r.Match(s); m.Success; m = m.NextMatch())
    {
        Console.WriteLine(m.Value);
    }
