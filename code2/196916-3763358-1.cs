    public static void CalculateWeek (out DateTime WeekStart, out DateTime WeekEnd, DateTime InputDate)
        {
            if (InputDate.DayOfWeek == DayOfWeek.Tuesday)
            {
                throw new ArgumentOutOfRangeException("InputDate", "Oh no, Tuesday!!");
            }
            DateTime tempDT = InputDate;
            while (tempDT.DayOfWeek != DayOfWeek.Wednesday)
            {
                tempDT = tempDT.AddDays(-1);
            }
            WeekStart = tempDT.Date;
            while (tempDT.DayOfWeek != DayOfWeek.Monday)
            {
                tempDT = tempDT.AddDays(1);
            }
            WeekEnd = tempDT.Date;
        }
