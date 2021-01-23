        int numday = 0;
        int dayofweek = 5; //friday
        DateTime thirdfriday;
        for (int i = 0; i < (date.AddMonths(1) - date).Days && numday <3; i++)
        {
            if ((int)date.AddDays(i).DayOfWeek == dayofweek)
            {
                numday++;
            }
            if (numday == 3)
            {
                thirdfriday = date.AddDays(i);
            }
            
        }
