    var blacklist = new HashSet<int>(Enumerable.Range(3, 100));
    var query = Enumerable.Range(2, 98).Where(i => !blacklist.Contains(i));
    foreach (var item in query)
    {
        Console.WriteLine(item);
        if ((item % 2) == 0)
        {
            var value = 2 * item;
            blacklist.Remove(value);
        }
    }
