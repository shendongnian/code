    // A sample list with 100 integers
    var list = new List<int>();
    for (var i = 0; i < 100; i++)
    {
        list.Add(i);
    }
    // Get the top 20
    var top20 = list.OrderByDescending(x => x).Take(20);
