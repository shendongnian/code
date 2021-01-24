    // DummyData
    List<DateTime> dates = new List<DateTime>
    {
        DateTime.Parse("2019/01/31 11:50"),
        DateTime.Parse("2019/02/02 17:21"),
        DateTime.Parse("2019/03/01 17:59"),
        DateTime.Parse("2019/03/12 10:54"),
        DateTime.Parse("2019/05/28 11:15"),
    };
    // Storage for final Output
    List<DateTime> finalOp = new List<DateTime>();
    // Main logic goes here
    // foreach Hour in list we will compare that with every other Hour in list
    // and it is in 1 hour range we will add it to list
    foreach (DateTime dateTime in dates)
    {
        List<DateTime> temp = new List<DateTime>();
        foreach (DateTime innerDateTime in dates)
        {
            // find the difference between two hours
            var timeSpan = dateTime.TimeOfDay - innerDateTime.TimeOfDay;
            // add it to same list if we have +/- 1 Hour difference
            if (timeSpan.TotalHours <= 1 && timeSpan.TotalHours >= -1)
            {
                temp.Add(innerDateTime);
            }
        }
        // once we have final group for date we will check if this has maximum number of common dates around
        // if so replace it with previous choice
        if (finalOp.Count < temp.Count)
        {
            finalOp = temp;
        }
    }
    // print the results
    foreach (var data in finalOp)
    {
        Console.WriteLine(data.ToShortTimeString());
    }
