    List<IEnumerable<int>> b = new List<IEnumerable<int>>();
    for (int i = 1; i <= 2; ++i)
    {
        int temp = i;
        b.Add(someData.Where(n => n == temp));
    }
