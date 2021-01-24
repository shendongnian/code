     DispatcherTimer timer_log = new DispatcherTimer();
     timer_log.Tick += timer_log_Tick;
     int Log = 0,LogDuration=0;
     public void set_timer_log(int interval)
       {
        timer_log.Interval = TimeSpan.FromMilliseconds(interval);
        timer_log.IsEnabled = true;
       }
    private void timer_log_Tick(object sender, EventArgs e)
       {
         timer_log.IsEnabled = false;
        try
          {
            if (Log < logs.Length)
               {
                add_package_log(logs[Log]);
                Log++;
                LogDuration++;
                set_timer_log(log_durations[LogDuration]);
               }
          }
        catch (Exception ex)
        {
            MessageBox.Show("Timer Log Tick  Function Error:" + ex.Message);
        }
    }
