    public static void CalculateWeek (out DateTime WeekStart, out DateTime WeekEnd, DateTime InputDate)
        {
            DateTime tempDT = InputDate;
            while (tempDT.DayOfWeek != DayOfWeek.Wednesday)
            {
                tempDT = tempDT.AddDays(-1);
            }
            WeekStart = tempDT.Date;
            while (tempDT.DayOfWeek != DayOfWeek.Tuesday)
            {
                tempDT = tempDT.AddDays(1);
            }
            WeekEnd = tempDT.Date;
        }
