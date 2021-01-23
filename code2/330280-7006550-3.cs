    // Note that you'll have to assign values to StartDate and EndDate, otherwise you'll get
    // a Null Reference Exception
    DateTime StartDate;
    DateTime EndDate;
    Datetime tempDate = StartDate;
    List<DateTime> dateToEvaluate;
    foreach (var tempItem in TaskList)
    {
        // Reset tempDate to the starting date before each loop
        tempDate = StartDate;
        while (EndDate.AddDays(1) != tempDate)
        {
            if (tempDate.DayOfWeek != DayOfWeek.Sunday)
            {
                if (tempItem.Date[0] == tempDate)
                {
                    tempTask.Add(new GroupedTask { ID = tempItem.ID,
                                                   TaskID = tempItem.TaskID,
                                                   Date = tempItem.Date });
                }
                else
                {
                    dateToEvaluate = new List<DateTime>();
                    dateToEvaluate.Add(tempDate);
                    tempTask.Add(new GroupedTask { ID = null,
                                                   TaskID = null,
                                                   Date = dateToEvaluate });
                }
            }   
         
            tempDate = tempDate.AddDays(1);
        }
    }
