    List<IEnumerable<int>> b = new List<IEnumerable<int>>();
    for (int i = 1; i <= 2; ++i)
    {
        int j = i;  // essential
        b.Add(someData.Where(n => n == j));
    }
