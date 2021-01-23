    using System.Timers;
    using System.Threading.Tasks;
    .
    .
    .
    var timer = new Timer(250);
    .
    .
    .
    private void Initialize()
    {
        timer.Elapsed += (o, s) => Task.Factory.StartNew(() => OnTimerElapsed(o, s));
        timer.Start();
    }
    .
    .
    .
    private void OnTimerElapsed(object o, ElapsedEventArgs s)
    {
        //Do stuff
    }
