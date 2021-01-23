    var counts = new Dictionary<char, int>();
    foreach(var c in s)
    {
        int count;
        if(!counts.TryGetValue(c, out count))
        {
            counts.Add(c, 1);
        }
        else
        {
            ++counts[c];
        }
    }
