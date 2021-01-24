    // Construct an array, with month as index and days as value
    int[] monthDays = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    
    // Count the number of days up to the given month
    int days = 0;
    for (int i = 0; i < month - 1; i++)
    {
        days += monthDays[i];
    }
    
    // Add the given number of days
    days += day
    
    // Divide by 7 to get the week of the year
    int weekOfYear = (int)Math.Ceiling((double)days / 7);
