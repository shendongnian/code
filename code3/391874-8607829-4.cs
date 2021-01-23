    public class buzzz
    {
    
       MessageBoxResult alarmBox;
       DispatchTimer alarmTimer = new DispatchTimer();
       var vibrationLength = 1000.0;
       var timerIncrease = 1.2;
       VibrateController vibrate = VibrateController.Default;
    
       public buzz()
       {
          alarmTimer.Interval = TimeSpan.FromMillseconds(vibrationLegnth * timerIncrease);
          alarmTimer.Tick += alarmTimer_Tick
       }
       public void startBuzz()
       {
           SoundEffectInstance alarmSound = PlaySound(@"Alarms/"+alarmSoundString);
           vibrate.Start(new TimeSpan(0,0,0,0,vibrationLength));
           alarmTimer.Start();
           alarmBox = MessageBox.Show("Press OK to stop alarm", "Timer Finished", MessageBoxButton.OK);
        }
        void alarmTimer_Tick(object sender, EventArgs e)
            {
               if(alarmBox == MessageBoxResult.OK)
               {
                  alarmTimer.Stop();
                  vibrate.Stop();
               }
               else
               {
                   vibrate.Start(new TimeSpan(0,0,0,0,vibrationLength));
               }
            }
    }
