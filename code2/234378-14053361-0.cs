    public int GetMonths(DateTime startDate, DateTime endDate)
    {
        if (startDate > endDate)
        {
            throw new Exception("Start Date is greater than the End Date");
        }
        int months = ((endDate.Year * 12) + endDate.Month) - ((startDate.Year * 12) + startDate.Month);
        if (endDate.Day >= startDate.Day)
        {
            months++;
        }
        return months;
    }
