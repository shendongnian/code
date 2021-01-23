    //The feedCodes (i put one in two times, to have one appearing most often)
    var values = new string[] { "9051245", "9051246", "9051247", null, "", "9051245", "9031454", "9021447" };
    //Just filter the list for filled up values
    var query = values.Where(value => !String.IsNullOrEmpty(value))
                        //and group them by their starting text
                      .GroupBy(value => value.Substring(0, 3))
                        //order by the most occuring group first
                      .OrderByDescending(group => group.Count());
    //Iterate over all groups or just take the first one with query.First() or query.FirstOrDefault()
    foreach (var group in query)
    {
        Console.WriteLine(group.Key + "  Count: " + group.Count());
    }
