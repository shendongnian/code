    // Assuming date 1 is the later date
    DateTime newDate = new DateTime(myDate1.Ticks - myDate2.Ticks);
    
    // NOTE : you might need to take 1 off each property, as they start at 1
    string.Format("{0} Years, {1} Months, {2} Days", newDate.Year, newDate.Month, newDate.Day);
