    class a
    {
      protected System.Windows.Forms.Timer bindTimer;
      private void Timer_Tick(object sender, EventArgs e)
      {
      }
      public a()
      {
        bindTimer.Tick += Timer_Tick;
      }
    }
