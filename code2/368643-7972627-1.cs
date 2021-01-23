    List<IEnumerable<int>> b = new List<IEnumerable<int>>();
    for (int i = 1; i <= 2; ++i)
    {        
        b.Add(someData.Where(n => n == i).ToList());
    }
