    public static int CalcLastMonthInQuarter(DateTime dt)
    {
        return 3 * ((dt.Month - 1) / 3 + 1);
    }
    
    public static string CalcLastMonthInQuarterStr(DateTime dt)
    {
        return CalcLastMonthInQuarter(dt).ToString("00");
    }
