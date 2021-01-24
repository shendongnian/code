    var timer = new Timer();
    timer.Elapse += OnTimerFired;
    timer.Interval = 1000;
    timer.Start();
...
    private static async void Register()
    {
       await Task.Delay(1000);
       // this is going to terminate your process!
       throw new Exception();
    }
