    private object _lock = new object(); //should have class scope
    
    private void ShowProgressControl(EventArgs e)
    {
      if (this.InvokeRequired)
      {
        lock (_lock)
        {
          EventHandler d = new EventHandler(ShowProgressControl);
          this.Invoke(d, new object[] { e });
          return;
        }
      }
      else
      {
        //show your progress bar
      }
    }
