    DateTime date = LimitVmodel.StartDate;
    
    switch (LimitVmodel) {
        case "Monday":
            while (date.DayOfWeek != DayOfWeek.Monday) {
                date = date.AddDays(1);
            }
        break;
        case "Tuesday":
            while (date.DayOfWeek != DayOfWeek.Tuesday) {
                date = date.AddDays(1);
            }
        break;
        //Etc...
    }
    AllDates.add(date);
    while (DateTime.compare(date, LimitVmodel.EndDate) <= 0) {
        date = date.AddDays(7);
        AllDates.add(date);
    }
