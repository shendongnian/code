    private void StartTimer()
    {
        System.Threading.Timer timer = 
            new System.Threading.Timer(
                TimerCompleted, 
                null, 
                TimeSpan.FromMinutes(15), 
                TimeSpan.FromMinutes(15));
    }
    private void TimerCompleted(object state)
    {
        // Call your action here
        ProcessFiles();
    }
