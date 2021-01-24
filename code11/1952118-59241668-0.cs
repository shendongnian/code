csharp
private DispatcherTimer _timer;
private static DateTime liveDateTime = DateTime.Now;
public ViewModel()
{
    _timer = new DispatcherTimer();
    _timer.Interval = TimeSpan.FromSeconds(1);
    _timer.Tick += Timer_Tick;
    _timer.Start();
    // other code ...
}
private void Timer_Tick(object sender, object e)
{
    liveDateTime = DateTime.Now;
}
Since it is not known when to start the timer, using one minute as the timing interval may cause delay. It is recommended to shorten the timer interval to 10 seconds or less.
Best regards.
