    var shows = new[]
                {
                    new DateTime(2010, 7, 28, 11, 15, 0),
                    new DateTime(2010, 7, 29, 8, 50, 0),
                    new DateTime(2010, 7, 29, 8, 55, 0)
                };
    var dates = shows.GroupBy(d => d.Date).OrderBy(d => d.Key);
    foreach (var date in dates)
    {
        Console.WriteLine("Date {0}", date.Key.ToShortDateString());
        var hours = date.GroupBy(d => d.Hour).OrderBy(d => d.Key);
        Console.WriteLine("\tHours\tCount");
        foreach (var hour in hours)
            Console.WriteLine("\t{0}-{1}\t{2}", hour.Key, (hour.Key+1)%24, hour.Count());
    }
