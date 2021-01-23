    public static DateTime GetMonthEnd(DateTime StartDate, int MonthsCount = 1)
    {
        return StartDate.AddMonths(MonthsCount).AddDays(-1);
    }
    public static Tuple<int, int> CalcPeriod(DateTime StartDate, DateTime EndDate)
    {
        int MonthsCount = 0;
        Tuple<int, int> Period;
        while (true)
        {
            if (GetMonthEnd(StartDate) > EndDate)
                break;
            else
            {
                MonthsCount += 1;
                StartDate = StartDate.AddMonths(1);
            }
        }
        int RemainingDays = (EndDate - StartDate).Days + 1;
        Period = new Tuple<int, int>(MonthsCount, RemainingDays);
        return Period;
    }
