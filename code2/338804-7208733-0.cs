    DateTime maxDate = default(DateTime);
    YourClass maxItem = null;
    
    foreach (var item in lstDates)
    {
        if (item.EndDate > maxDate)
        {
            maxDate = item.EndDate;
            maxItem = item;
        }
    }
