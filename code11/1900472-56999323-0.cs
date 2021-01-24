    var possibleDate = context.FirstDay.AddDays(dayOne);
    for (var i = 0; i <= 3; i++)
    {
        possibleDate = possibleDate.AddDays(1);
        if (!_storeScheduleService.IsStoreOpenForDate(storeId, possibleDate)) continue;
        ...
    }
