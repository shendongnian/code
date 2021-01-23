    Timespan timespan = someUtcTime.Subtract(DateTime.UtcNow);
    long time = timespan.TotalMilliseconds <= long.MaxValue ? (long)timespan.TotalMilliseconds : -1;
    
    if (time == -1) {
     sorry.nocando();
    }
    else {
     just.doit();
    }
