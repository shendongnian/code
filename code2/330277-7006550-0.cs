    // Note that you'll have to assign values to StartDate and EndDate, otherwise you'll get
    // a Null Reference Exception
    DateTime StartDate;
    DateTime EndDate;
    Datetime tempDate = StartDate;
    List<DateTime> dateToEvaluate;
    bool TimeIsPresent;
    foreach (var tempItem in TaskList)
    {
        // Set the TimeIsPresent flag to false for each item in TaskList
        TimeIsPresent = false;
        // Loop through the date range until either no matches where found or a match
        // was found
        while (EndDate.AddDays(1) != tempDate  && !TimeIsPresent)
        {
            if (tempItem.Date[0] == tempDate)
            {
                tempTask.Add(new GroupedTask { ID = tempItem.ID,
                                               TaskID = tempItem.TaskID,
                                               Date = tempItem.Date });
                TimeIsPresent = true;
            }
            if (tempDate.DayOfWeek != DayOfWeek.Sunday)
            {
                dateToEvaluate = new List<DateTime>();
                dateToEvaluate.Add(tempDate);
                tempTask.Add(new GroupedTask { ID = null,
                                               TaskID = null,
                                               Date = dateToEvaluate });
            }
            tempDate = tempDate.AddDays(1);
        }
    }
