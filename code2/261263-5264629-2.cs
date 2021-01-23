    // Just an example, implement as you prefer...
    public bool OverlappedTo(this DateRange range1, DateRange range2)
    {
        var duration1 = range1.End - range1.Start;
        var duration2 = range2.End - range2.Start;
    
        var minStart = range1.Start < range2.Start ? range1.Start : range2.Start;
        var maxEnd = range1.End > range2.End ? range1.End : range2.End;
    
        var totalDuration = maxEnd - minStart;
    
        // if the sum of the 2 durations is less than 
        // the total duration --> overlapped
        return duration1 + duration2 < totalDuration;
    }
