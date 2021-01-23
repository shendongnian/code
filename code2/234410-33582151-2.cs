    private double ReturnDiffereceBetweenTwoDatesInMonths(DateTime startDateTime, DateTime endDateTime)
    {
        double result = 0;
        double days = 0;
        DateTime currentDateTime = startDateTime;
        while (endDateTime > currentDateTime.AddMonths(1))
        {
            result ++;
            currentDateTime = currentDateTime.AddMonths(1);
        }
        if (endDateTime > currentDateTime)
        {
            days = endDateTime.Subtract(currentDateTime).TotalDays;
        }
        return result + days/endDateTime.GetMonthDays;
    }
