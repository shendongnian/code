    public Tuple<int, string> SplitItem(string item)
    {
        var parts = item.Split(new[] { '.' });
        return Tuple.Create(int.Parse(parts[0]), parts[1].Trim());
    }
    var tokens = SplitItem("1. abc");
    int number = tokens.Item1;  // 1
    string str = tokens.Item2;  // "abc"
