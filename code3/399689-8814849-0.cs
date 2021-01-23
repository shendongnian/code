    var temp = new List<string>();
    foreach (var s in test)
    {
        if (!string.IsNullOrEmpty(s))
            temp.Add(s);
    }
    test = temp.ToArray();
