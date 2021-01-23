    private static EnterpriseLibraryPerformanceCounter averageRequestTimeCounter = PerformanceCounterManager.GetEnterpriseLibraryCounter(MadPerformanceCountersListener.AverageRequestTime);
    private static EnterpriseLibraryPerformanceCounter averageRequestTimeCounterBase = PerformanceCounterManager.GetEnterpriseLibraryCounter(MadPerformanceCountersListener.AverageRequestTimeBase);
    
    public void DoSomethingWeWantToMonitor()
    {
    	using (new AverageTimeMeter(averageRequestTimeCounter, averageRequestTimeCounterBase))
    	{
    		// code here that you want to perf mon
    	}
    }
