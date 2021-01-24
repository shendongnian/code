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
