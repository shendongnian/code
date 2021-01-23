    static LinqMPISMPPCalenderDataContext DBCalender;
    DBCalender = new LinqMPISMPPCalenderDataContext(connectionString);
    var ExceptionPeriod = DBCalender.Table_ExceptionPeriods
        .Where(table=>Table.StartDate<= Date && table.FinishDate >= Date && table.CalenderID==CalenderID).Single();
    ExceptionPeriod.StartDate = ExceptionPeriod.StartDate.AddDays(1);
    DBCalender.SubmitChanges();
