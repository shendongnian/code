    async void ScheduleJob(object s, EventArgs e)
    {           
        DependencyService.Get<IJobSchedulerService>().StartJobSchedule();              
    }
    //Button OnClickEvent
    async void CancelJob(object s, EventArgs e)
    {
        DependencyService.Get<IJobSchedulerService>().CancelJobSchedule();
    }
