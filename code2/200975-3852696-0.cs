    static string GetDateRangeString(DateTime startDate, DateTime endDate)
    {
        if (endDate.Year != startDate.Year)
        {
            return startDate.ToString("M/d/yyyy") + "-" + endDate.ToString("M/d/yyyy");
        }
        else if (endDate.Month != startDate.Month)
        {
            return startDate.ToString("M/d") + "-" + endDate.ToString("M/d/yyyy");
        }
        else
        {
            return startDate.ToString("M/d") + "-" + endDate.ToString("d/yyyy");
        }
    }
