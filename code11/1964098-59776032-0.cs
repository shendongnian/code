private DispatcherTimer _uiUpdateTimer;
...
_uiUpdateTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
_uiUpdateTimer.Tick += OnTick;
...
if(_uiUpdateTimer.IsEnabled && _sessionState.HasValue)
{
    ... Your code goes here
}
...
private void OnTick(object sender, EventArgs e)
{
    ... Your code goes here
}
I hope this helps.
