    // Note that you'll have to assign values to StartDate and EndDate, otherwise you'll get
    // a Null Reference Exception
    DateTime StartDate;
    DateTime EndDate;
    
    // Declare an instance of GroupedTask for use in the while loop
    GroupedTask newTask;
    Datetime tempDate = StartDate;
    // Loop through the entire range of dates
    while (EndDate.AddDays(1) != tempDate)
    {
        // You included Sundays in your example, but had earlier indicated they
        // weren't needed.  If you do want Sundays, you can remove this outer if
        // block
        if (tempDate.DayOfWeek != DayOfWeek.Sunday)
        {
    
            // Create a "null" GroupedTask object
            // The Date property in GroupedTask appears to be a List<DateTime>,
            // so I chose to initialize it along with the other properties.
            newTask = new GroupedTask() { ID = null,
                                          TaskID = null,
                                          Date = new List<DateTime>() { tempDate }};
            // For each date in the range, check to see if there are any tasks in the TaskList
            foreach (var tempItem in TaskList)
            {
                // If the current item's date matches the current date in the range,
                // update the newTask object with the current item's values.
                // NOTE:  If more than one item has the current date, the last one in
                // will win as this code is written.
                if (tempItem.Date[0] == tempDate)
                {
                    newTask.ID = tempItem.ID;
                    newTask.TaskID = tempItem.TaskID;
                    newTask.Date = tempItem.Date;
                }
            }
            // Add the newTask object to the second list
            tempTask.Add(newTask);
        }
    }
