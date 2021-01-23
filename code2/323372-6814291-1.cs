    private static TimeSpan FindOverlap(ParkingTime parkingTime, TimeZone timeZone)
    {
        // Handle wraparound zones like 23-6. Note that this doesn't attempt
        // to handle *parking* which starts at 11.30pm etc.
        if (timeZone.Start > timeZone.End)
        {
            return FindOverlap(parkingTime,
                         new TimeZone(timeZone.Start.Date, timeZone.End)
                 + FindOverlap(parkingTime,
                         new TimeZone(timeZone.End, timeZone.Start.Date.AddDays(1));
        }
        DateTime overlapStart = Max(parkingTime.Start, timeZone.Start);
        DateTime overlapEnd = Min(parkingTime.End, timeZone.End);
        TimeSpan overlap = overlapEnd - overlapStart;
        // If the customer arrived after the end or left before the start,
        // the overlap will be negative at this point.
        return overlap < TimeSpan.Zero ? TimeSpan.Zero : overlap;
    }
    private static DateTime Min(DateTime x, DateTime y)
    {
        return x < y ? x : y;
    }
    private static DateTime Max(DateTime x, DateTime y)
    {
        return x > y ? x : y;
    }
