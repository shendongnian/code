    public IEnumerable<DateTime> GetHalfAnHourChunks(DateTime startFrom, DateTime until)
    {
        while(startFrom < until)
        {
            yield return startFrom;
            startFrom = startFrom.AddMinutes(30);
        }
    }
