    Dictionary<int, string> d = items.ToDictionary(x => x.Index, x => x.Text);
    List<string> result = new List<string>();
    for (int i = 0; i < d.Keys.Max() + 1; ++i)
    {
        string s;
        d.TryGetValue(i, out s);
        result.Add(s);
    }
