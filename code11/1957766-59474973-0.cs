    var task1 = core.ProcessOne(DurationX);
    var task2 = core.ProcessTwo(DurationY);
    await Task.WhenAll(task1, task2);
    .
    .
    .
    public async Task ProcessOne(double Time) // I assume Time is in seconds
    {
    // Start Process
    await Task.Delay(Time * 1000);
    // End Process
    }
    public async Task ProcessTwo(double Time)
    {
    await Task.Delay(MixingTime * 1000);
    // Start Process
    await Task.Delay(Time * 1000);
    // End Process
    }
