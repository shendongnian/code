    public static string GetChromeUrl(Process process)
    {
        if (process == null)
            throw new ArgumentNullException("process");
        if (process.MainWindowHandle == IntPtr.Zero)
            return null;
        AutomationElement element = AutomationElement.FromHandle(process.MainWindowHandle);
        if (element == null)
            return null;
        AutomationElement edit = element.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
        return ((ValuePattern)edit.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
    }
    public static string GetInternetExplorerUrl(Process process)
    {
        if (process == null)
            throw new ArgumentNullException("process");
        if (process.MainWindowHandle == IntPtr.Zero)
            return null;
        AutomationElement element = AutomationElement.FromHandle(process.MainWindowHandle);
        if (element == null)
            return null;
        AutomationElement rebar = element.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "ReBarWindow32"));
        if (rebar == null)
            return null;
        AutomationElement edit = rebar.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
        
        return ((ValuePattern)edit.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
    }
    public static string GetFirefoxUrl(Process process)
    {
        if (process == null)
            throw new ArgumentNullException("process");
        if (process.MainWindowHandle == IntPtr.Zero)
            return null;
        AutomationElement element = AutomationElement.FromHandle(process.MainWindowHandle);
        if (element == null)
            return null;
        AutomationElement doc = element.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document));
        if (doc == null)
            return null;
        return ((ValuePattern)doc.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
    }
