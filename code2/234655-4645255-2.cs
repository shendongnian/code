    TimeSpan upTime;
    using (var pc = new PerformanceCounter("System", "System Up Time"))
    {
        pc.NextValue();    //The first call returns 0, so call this twice
        upTime = TimeSpan.FromSeconds(pc.NextValue());
    }
    Console.WriteLine(upTime.ToString());
