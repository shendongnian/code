c#
using System.Diagnostics;
using Gma.System.MouseKeyHook;
Code:
c#
// Global hook
private IKeyboardMouseEvents _globalHook;
// Stopwatch to count the amount of time the global mouse down events are blocked
private Stopwatch _stopwatch = new Stopwatch();
// The amount of time to block global mouse down events
private TimeSpan _timeSpan;
// Attach global hook
private void Subscribe()
{
    _globalHook = Hook.GlobalEvents();
    _globalHook.MouseDownExt += GlobalHookMouseDownExt;
}
// Remove global hook
private void Unsubscribe()
{
    _globalHook.MouseDownExt -= GlobalHookMouseDownExt;
    _globalHook.Dispose();
}
// Global hook mouse down event 
private void GlobalHookMouseDownExt(object sender, MouseEventExtArgs e)
{
    if(_stopwatch.IsRunning)
    {
        if(_stopwatch.Elapsed < _timeSpan)
        {
            e.Handled = true;
        }
        else
        {
            _stopwatch.Stop();
        }
    }
}
// Block global mouse down events for timeSpan amount of time
private void BlockMouseDown(TimeSpan timeSpan)
{
    _timeSpan = timeSpan;
    _stopwatch.Restart();
}
Usage:
c#
// Attach global hook
Subscribe();
...
// Block mouse down event for 10 seconds
BlockMouseDown(TimeSpan.FromSeconds(10));
