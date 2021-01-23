    Dictionary<int, string> dict = new Dictionary<int, string>
    { 
        {3, "kuku" },
        {1, "zOl"}
    };
    IEnumerable<int> data = new List<int> { 1, 2, 4 };
    IEnumerable<int> toRemove = data.Except(dict.Keys);
    foreach(var x in toRemove)
        dict.Remove(x);
