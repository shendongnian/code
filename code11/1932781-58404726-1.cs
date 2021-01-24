    class a
    {
      protected System.Windows.Forms.Timer bindTimer;
      public event EventHandler OnTimer;
      private void Timer_Tick(object sender, EventArgs e)
      {
        OnTimer(sender, e);
      }
      public a()
      {
        bindTimer.Tick += Timer_Tick;
      }
    }
