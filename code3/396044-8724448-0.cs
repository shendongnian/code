    public TimePeriod(DateTime startTime , DateTime endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }
    public TimePeriod(DateTime startTime , TimeSpan length)
    {
        StartTime = startTime;
        EndTime = startTime + length;
    }
    public TimeSpan GetDuration()
    {
        return EndTime - StartTime;
    }
    //Else you can just get the StartTime or EndTime variable (DateTime)
