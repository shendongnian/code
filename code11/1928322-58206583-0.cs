    public IActionResult StopSender()
    {
        JobManager.RemoveAllJobs();
        
        return RedirectToAction("Index");
    }
    
    public IActionResult StartSender()
    {
        var registry = new Registry();
        registry.Schedule<SendPushesJob>().ToRunNow().AndEvery(60).Seconds();
        JobManager.Initialize(registry);
        return RedirectToAction("Index");
    }
