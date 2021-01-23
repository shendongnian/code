    try {
        throw new WeekdayException("Tuesday");
    }
    catch(WeekdayException weekdayException) {
        Console.WriteLine(weekdayException.Message);
    }
