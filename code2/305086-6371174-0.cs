    void Tick()
    {
        while (true)
        {
            textBlock1.Dispatcher.Invoke(
                DispatcherPriority.Normal,
                new Action(
          delegate()
          {
              textBlock1.Text = DateTime.Now.ToString("h:mm:ss");
          }
            ));
              // Executed on background thread, not UI thread
              Thread.Sleep(1000);
        }
    }
