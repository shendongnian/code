    public void RunScheduledMethod(Action methodToRun, TimeSpan timeToRun)
        {
            if (timeToRun <= DateTime.Now.TimeOfDay)
                timeToRun = timeToRun + new TimeSpan(1, 0, 0, 0);
            timeToRun -= DateTime.Now.TimeOfDay;
            Task.Delay(timeToRun).ContinueWith(t => methodToRun());
        }
