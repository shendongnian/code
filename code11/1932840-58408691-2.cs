    private async void InitializeTimer()
    {
         while (!timer.Enabled) //keep looping until timer is initialized
         {
             //if the minute is a multiple of 5 (:00, :05, ...) start the timer
             if (DateTime.Now.Minute % 5 == 0 && DateTime.Now.Second == 0)
             {
                 timer.Start();
                 TriggerAlarm(); //trigger the alarm initially instead of having to wait 5min
             }
             else
             {
                 await Task.Delay(100);
             }            
         }        
    }
