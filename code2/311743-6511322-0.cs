     DateTime date = DateTime.Now;
            DateTime saturday;
            DateTime sunday;
            if (date.DayOfWeek == DayOfWeek.Monday)
            {
                saturday = date.AddDays(5);
                sunday = date.AddDays(6);
            }else if (date.DayOfWeek == DayOfWeek.Tuesday)
            {
                saturday = date.AddDays(4);
                sunday = date.AddDays(5);
            }
            else if (date.DayOfWeek == DayOfWeek.Wednesday)
            {
                saturday = date.AddDays(3);
                sunday = date.AddDays(4);
            }
            else if (date.DayOfWeek == DayOfWeek.Thursday)
            {
                saturday = date.AddDays(2);
                sunday = date.AddDays(3);
            }
            else if (date.DayOfWeek == DayOfWeek.Friday)
            {
                saturday = date.AddDays(1);
                sunday = date.AddDays(2);
            }
            else if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                saturday = date.AddDays(0);
                sunday = date.AddDays(1);
            }
            else if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                saturday = date.AddDays(-1);
                sunday = date.AddDays(0);
            }
