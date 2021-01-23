        System.Diagnostics.PerformanceCounterCategory pc;
        pc = new System.Diagnostics.PerformanceCounterCategory("ReadyBoost Cache");
        foreach (PerformanceCounter counter in pc.GetCounters())
        {
            if (counter.CounterName == "Bytes cached")
            {
                //to do
            }
        }
