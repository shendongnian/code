    int skippedDays = 0;
    for (var i = 0; i <= 3; i++)
    {
       var possibleDate = context.FirstDay.AddDays(dayOne + i + skippedDays);
        possibleDate = possibleDate.AddDays(1);
        if (!_storeScheduleService.IsStoreOpenForDate(storeId, possibleDate))
        {
             skippedDays++;
             continue;
        }
        ...
    }
