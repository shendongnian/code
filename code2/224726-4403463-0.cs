    public static IEnumerable<DateTime> FindMissingDates(IEnumerable<DateTime> input)
    {
        // get the range of dates to check
        DateTime from = input.Min();
        DateTime to = input.Max();
        // how many days?
        int numberOfDays = to.Subtract(from).Days;
        // create an IEnumerable<DateTime> for all dates in the range
        IEnumerable<DateTime> allDates = Enumerable.Range(0, numberOfDays)
            .Select(n => from.AddDays(n));
    
        // return all dates, except those found in the input
        return allDates.Except(input);
    }
