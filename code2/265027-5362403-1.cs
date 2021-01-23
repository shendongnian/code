    DateTime StartingDate = DateTime.Parse("02/25/2007");
    DateTime EndingDate = DateTime.Parse("03/06/2007");
    foreach (DateTime date in GetDateRange(StartingDate,EndingDate))
    {
       WL(date.ToShortDateString()); 
    } 
