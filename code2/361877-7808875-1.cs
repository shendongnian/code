    private static readonly LocalTimePattern TimePattern = 
         LocalTimePattern.CreateWithInvariantInfo("HH:mm");
    ...
    public int CompareTimes(string t1, string t2)
    {
        // These will throw if the values are invalid. Use TryGetValue
        // or the Success property to check first...
        LocalTime time1 = TimePattern.Parse(t1).Value;
        LocalTime time2 = TimePattern.Parse(t2).Value;
        return time1.CompareTo(time2);
    }
    
