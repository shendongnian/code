    public static DateTime AddWorkDays(this DateTime date, int workingDays, params Holidays[] bankHolidays)
        {
            int direction = workingDays < 0 ? -1 : 1;
            DateTime newDate = date;
            // If a working day count of Zero is passed, return the date passed
            if (workingDays == 0)
            {
                newDate = date;
            }
            else
            {
                while (workingDays != -direction)
                {
                    if (newDate.DayOfWeek != DayOfWeek.Saturday &&
                        newDate.DayOfWeek != DayOfWeek.Sunday &&
                        Array.IndexOf(bankHolidays, newDate) < 0)
                    {
                        workingDays -= direction;
                    }
                    // if the original return date falls on a weekend or holiday, this will take it to the previous / next workday, but the "if" statement keeps it from going a day too far.
                    if (workingDays != -direction)
                    { newDate = newDate.AddDays(direction); }
                }
            }
            return newDate;
        }
