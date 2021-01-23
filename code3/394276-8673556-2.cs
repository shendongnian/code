    // Sample times and full hour
    DateTime lastSampleTimeBeforeFullHour = new DateTime(2011, 12, 19, 17, 58, 21);
    DateTime firstSampleTimeAfterFullHour = new DateTime(2011, 12, 19, 18, 13, 21);
    DateTime fullHour = new DateTime(2011, 12, 19, 18, 00, 00);
    
    // Times as ticks (most accurate time unit)
    long t0 = lastSampleTimeBeforeFullHour.Ticks;
    long t1 = firstSampleTimeAfterFullHour.Ticks;
    long tf = fullHour.Ticks;
    
    // Energy samples
    double e0 = 79179.88; // kWh before full hour
    double e1 = 79182.13; // kWh after full hour
    double ef; // interpolated energy at full hour
    
    ef = e0 + (tf - t0) * (e1 - e0) / (t1 - t0); // ==> 79180.1275 kWh
