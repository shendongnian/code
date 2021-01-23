    private static readonly DispatcherTimer myTimer = new DispatcherTimer();
     myTimer .Interval = TimeSpan.FromSeconds(5);
                myTimer .Tick += myTimerTick;
                myTimer .Start();
...
     private void myTimerTick(object sender, EventArgs e)
            {
               //do something here
            }
