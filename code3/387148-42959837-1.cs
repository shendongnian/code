    Date returnDate;
    if (numberOfPayments % 2 == 0)
    {
       returnDate = date.AddMonths(numberOfPayments / 2);
        if (date.Day == DateTime.DaysInMonth(date.Year, date.Month))//Last day of the month adjustment
        {
            returnDate = new Date(returnDate.Year, returnDate.Month, DateTime.DaysInMonth(returnDate.Year, returnDate.Month));
        }
    }
    else
    {
        returnDate = date.Day <= 15 ? date.AddDays(15).AddMonths((numberOfPayments - 1) / 2) : date.AddDays(-15).AddMonths((numberOfPayments + 1) / 2);
        if (date.Day == DateTime.DaysInMonth(date.Year, date.Month))//Last day of the month adjustment
        {
            returnDate = new Date(returnDate.Year, returnDate.Month, 15);
        }
        else if (date.Month == 2 && date.Day == 14)
        {
            returnDate = returnDate.AddMonths(-1);
            returnDate = new Date(returnDate.Year, returnDate.Month, returnDate.Month == 2 ? 28 : 29);
        }
        else if (date.Month == 2 && date.Day == 15)
        {
            returnDate = returnDate.AddMonths(-1);
            returnDate = new Date(returnDate.Year, returnDateMonth, DateTime.DaysInMonth(returnDate.Year, returnDate.Month));
        }
    }
    return returnDate;
