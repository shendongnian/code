    Date previousDate = null;
    foreach (var date in dateList) // using foreach works with any enumerable type
    {
        if (DateTime.Now > date.StartDate && DateTime.Now < date.EndDate)
        {
            if (previousDate != null)
            {
                // Do something
            }
            break;
        }
        previousDate = date;
    }
