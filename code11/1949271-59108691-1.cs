    for (int i = 0; i < dateList.Length; i++)
    {
        var date = dateList[i];
        if (DateTime.Now > date.StartDate && DateTime.Now < date.EndDate)
        {
            var previousDate = i > 0 ? dateList[i - 1] : null; // Figure out how you want to handle the case where the matching item is the first item in the list
            // Do something
            break; 
        }
    }
