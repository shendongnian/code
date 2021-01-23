    using System.Timers; 
    private timer = new Timer();
    protected override void OnStart(string[] args)
    {
     timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
     timer.Interval = 30000; // every 30 seconds
     timer.Enabled = true;
    }
    Private void OnElapsedTime(object source, ElapsedEventArgs e)
    {
       // Execute your code here
    }
 
