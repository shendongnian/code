    foreach (var period1Date in dates.Where(date => date >= startDatePeriod1 && 
                                                    date <= stopDatePeriod1))
    {
        adapterBonus.InsertPeriod1Query(// insert period1Date to database));
    }
    foreach (var period2Date in dates.Where(date => date >= startDatePeriod2 && 
                                                    date <= stopDatePeriod2))
    {
        adapterBonus.InsertPeriod2Query(// insert period2Date to database));
    }
