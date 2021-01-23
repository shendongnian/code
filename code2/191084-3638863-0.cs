    static int NumberOfParticularDaysInMonth(int year, int month, DayOfWeek dayOfWeek)
    {
        DateTime startDate = new DateTime(year, month, 1);
        int totalDays = startDate.AddMonths(1).Subtract(startDate).Days;
        int answer = Enumerable.Range(1, totalDays)
            .Select(item => new DateTime(year, month, item))
            .Where(date => date.DayOfWeek == dayOfWeek)
            .Count();
        return answer;
    }
...
    int numberOfThursdays = NumberOfParticularDaysInMonth(2010, 9, DayOfWeek.Thursday);
