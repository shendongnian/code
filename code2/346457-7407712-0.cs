        var year = 2011;
        var week = 37;
        var date = new DateTime(year, 1, 1);
        if (date.DayOfWeek != DayOfWeek.Friday)
        {
            do date = date.AddDays(1); 
            while (date.DayOfWeek != DayOfWeek.Friday);
        }
        date = date.AddDays(7 * (week - 1));
