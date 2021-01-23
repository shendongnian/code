    // Every 60 seconds I want to close/dispose my PerformanceCounter
    if (stateCounter % 60 == 0)
    {
        if (pcReqsPerSec != null)
        {
            pcReqsPerSec.Close();
            pcReqsPerSec.Dispose();
            pcReqsPerSec = null;
        }
    }
