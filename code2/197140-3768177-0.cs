    public IEnumerable<string> GetNames()
    {
        yield return "Joe";
        yield return "Jack";
        yield return "Jane";
    }
    foreach(string name in GetNames())
    {
        Console.WriteLine(name);
    }
