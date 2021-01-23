    //The feedCodes (i put one in two times, to have one appearing most often)
    var values = new string[] { "9051245", "9051246", "9051247", "9051245", "9031454", "9021447" };
    //Just filter the list by the first characters
    var query = values.Where(value => value.StartsWith("905"))
                      //and group them by their full name (maybe just a subset with value.Substring())
                      .GroupBy(value => value)
                      //order by the most occuring group first
                      .OrderByDescending(group => group.Count());
    //Iterate over all groups or just take the first one with query.First() or query.FirstOrDefault()
    foreach (var group in query)
    {
        Console.WriteLine(group.Key + "  Count: " + group.Count());
    }
