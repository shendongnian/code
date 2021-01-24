c#
ctrl.Enabled = isEnable;
ctrl.Invoke((MethodInvoker)(() => ctrl.Enabled = isEnable));
Since `Invoke` is required because we must access control handle only from the thread that created it, and if we're not sure whether we're running on that thread, we must use `InvokeRequired` and if it returns `true`, we must use `Invoke`. 
To cover both cases, we can factor the code like this:
c#
private static void InvokeControl(Control ctrl, Action<Control> action)
{
    if (ctrl.InvokeRequired)
    {
        ctrl.Invoke(() => action(ctrl));
    }
    else
    {
        action(ctrl);
    }
}
public static void Enable(this Control con, bool isEnable)
{
    if (con == null)
    {
        return;
    }
    foreach (Control ctrl in con.Controls)
    {    
        if (ctrl is TfSearchButton)
        {
            InvokeControl(ctrl, c => c.Enabled = isEnable);
        }
        //... implement the rest of the cases in similar way
    }
}
### UPDATE
Giving it some more thought, switching enabled state of multiple controls in this case is, logically, an atomic operation. In solution I suggested above, one call to `Enable()` would result in numerous context switches and thread blocking. To make the `Enable()` operation "a more atomic" technically, it's better to run `Enable()` entirely on the UI thread: 
c#
public static void Enable(this Control con, bool isEnable)
{
    if (con == null)
    {
        return;
    }
    if (con.InvokeRequired) // returns false if we're on the UI thread
    {
        // if we're not on the UI thread, enqueue a new call to Enable()
        // the call will be dequeued and executed by the UI thread
        con.BeginInvoke(() => Enable(con, isEnable));
        return; 
    }
    // if we got to this point, we're running on the UI thread
    foreach (Control ctrl in con.Controls)
    {    
        // since this code always runs on UI thread,
        // there is no need to use Invoke/BeginInvoke
        if (ctrl is TfSearchButton)
        {
            ctrl.Enabled = isEnable;
        }
        // ... the rest of the cases ...
    }
}
