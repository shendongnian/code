        DateTime start = new DateTime(2019,11,1,0,0,0);
        DateTime end = new DateTime(2019, 11, 3, 11, 0, 0);
        TimeSpan diff = end - start;
        int total = 0;
        for (int i = 0; i<=diff.Days; i++)
        {
            DateTime test = start.AddDays(i);
            if (test.DayOfWeek == DayOfWeek.Saturday ||  test.DayOfWeek == DayOfWeek.Saturday)
            {
                if (test == start)
                {
                    total += (24 - test.Hour) * 60 + (60 - test.Minute);
                }
                else if (test == end)
                {
                    total += test.Hour * 60 + test.Minute;
                }
                else total += 24 * 60;
            }
        }
