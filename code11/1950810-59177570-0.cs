     DispatcherTimer timer_log = new DispatcherTimer();
     timer_log.Tick += timer_log_Tick;
     int sayacLog = 0,sayacLogDuration=0;
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
            if (sayacLog < logs.Length)
               {
                add_package_log(logs[sayacLog]);
                sayacLog++;
                sayacLogDuration++;
                set_timer_log(log_durations[sayacLogDuration]);
               }
          }
        catch (Exception ex)
        {
            MessageBox.Show("Timer Log Tick  Function Error:" + ex.Message);
        }
    }
