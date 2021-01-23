    var dates = new[]
                        {
                            new DateTime(2011, 12, 25), 
                            new DateTime(2011, 11, 25),
                            new DateTime(2011, 5, 4),
                            new DateTime(2011, 1, 3), 
                            new DateTime(2011, 8, 9),
                            new DateTime(2011, 2, 14),
                            new DateTime(2011, 7, 4),
                            new DateTime(2011, 11, 11)
                        };
    
    var groupedByQuarter = from date in dates
                            group date by (date.Month - 1)/3
                            into groupedDates
                            orderby groupedDates.Key
                            select groupedDates;
                                       
    
    foreach(var quarter in groupedByQuarter)
    {
        Console.WriteLine("Q: {0}, Dates: {1}", quarter.Key, string.Join(", ", quarter));
    }
