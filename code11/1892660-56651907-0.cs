c#
using System.Diagnostics;
using Gma.System.MouseKeyHook;
Code:
c#
private IKeyboardMouseEvents _globalHook;
private Stopwatch _stopwatch = new Stopwatch();
private TimeSpan _timeSpan;
private void Subscribe()
{
    _globalHook = Hook.GlobalEvents();
    _globalHook.MouseDownExt += GlobalHookMouseDownExt;
}
private void Unsubscribe()
{
    _globalHook.MouseDownExt -= GlobalHookMouseDownExt;
    _globalHook.Dispose();
}
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
private void BlockMouseDown(TimeSpan timeSpan)
{
    _timeSpan = timeSpan;
    _stopwatch.Restart();
}
Usage:
c#
// Attach global hook
Subscribe();
// Block mouse down event for 10 seconds
BlockMouseDown(TimeSpan.FromSeconds(10));
...
