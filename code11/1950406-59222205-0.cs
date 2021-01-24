    while (!ct.IsCancellationRequested)
    {
       App.viewablePhrases = App.DB.GetViewablePhrases(Settings.Mode, Settings.Pts);
       await CheckAvailability();   //Your Code could be blocked here, unable to cancel
    }
