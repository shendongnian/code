    protected override void OnInvoke(ScheduledTask task)
    {
        // using ...
    
    #if DEBUG
        // If we're debugging, fire the task again
        string taskName = "Project One Tasks";
        ScheduledActionService.LaunchForTest(taskName, new TimeSpan(0, 0, 30));
    #endif
    
         NotifyComplete();
    }
