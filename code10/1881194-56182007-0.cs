    var dict = new Dictionary<string, int>();
    foreach(var item in titles1.Concat(titles2))
    {
        if(!dict.Contains(item)
        {
            dict.Add(item, 0);
        }
        else
        {
            dict[item]++;
        }
    }
