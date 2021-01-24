    // get the foreground window handle.
    // here I used the Windows GetForegroundWindow function but you can use
    // any function that defines what is the active/foreground window in your context
    var foreground = GetForegroundWindow();
    // get all Visual Studio main windows (from the desktop)
    foreach (AutomationElement child in AutomationElement.RootElement.FindAll(
        TreeScope.Children, new PropertyCondition(AutomationElement.AutomationIdProperty, "VisualStudioMainWindow")))
    {
        // note the unfortunate 32-bit that UI automation uses instead of IntPtr...
        // in practise that shouldn't be a problem
        if (child.Current.NativeWindowHandle == foreground.ToInt32())
        {
            // this is the foreground Visual Studio
            // get its DTE instance
            var obj = GetVisualStudioInstance(child.Current.ProcessId);        
        }
    }
    // see doc at https://docs.microsoft.com/en-us/previous-versions/ms228755(v=vs.140)
    public static object GetVisualStudioInstance(int processId)
    {
        CreateBindCtx(0, out var ctx);
        if (ctx == null)
            return null;
        ctx.GetRunningObjectTable(out var table);
        table.EnumRunning(out var enumerator);
        var monikers = new IMoniker[1];
        while (enumerator.Next(1, monikers, IntPtr.Zero) == 0)
        {
            monikers[0].GetDisplayName(ctx, null, out var name);
            if (Regex.Match(name, @"!VisualStudio.DTE\.[0-9]*\.[0-9]*:" + processId).Success)
            {
                table.GetObject(monikers[0], out var obj);
                return obj;
            }
        }
        return null;
    }
    [DllImport("user32")]
    private static extern IntPtr GetForegroundWindow();
    [DllImport("ole32")]
    private static extern int CreateBindCtx(int reserved, out IBindCtx ppbc); // from System.Runtime.InteropServices.ComTypes
