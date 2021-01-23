    public static int MonthDiff(DateTime date1, DateTime date2)
    {
        if (date1.Month < date2.Month)
        {
            return (date2.Year - date1.Year) * 12 + date2.Month - date1.Month;
        }
        else
        {
            return (date2.Year - date1.Year - 1) * 12 + date2.Month - date1.Month + 12;
        }
    }
