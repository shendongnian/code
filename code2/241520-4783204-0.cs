    //private void m_timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    
    System.Threading.Tasks.Task.Factory.StartNew(() =>
    {
      m_sync.Post((o) =>
      {
        label1.Text = m_count.ToString();
        Application.DoEvents();
      }, null);
    
      System.Threading.Thread.Sleep(1000;)
    
    }, System.Threading.Tasks.TaskCreationOptions.LongRunning);
