    public static void DownloadIEFile(this Browser browser)
    {
    // see information here (http://msdn.microsoft.com/en-  us/library/windows/desktop/ms633515(v=vs.85).aspx)
    Window windowMain = new Window(WatiN.Core.Native.Windows.NativeMethods.GetWindow(browser.hWnd, 5));
   
    Window windowDialog = new
    Window(WatiN.Core.Native.Windows.NativeMethods.GetWindow(windowMain.Hwnd, 5));
    // if doesn't work try to increase sleep interval or write your own waitUntill method
    Thread.Sleep(1000);
    windowDialog.SetActivate();
    System.Windows.Automation.AutomationElementCollection amc =       System.Windows.Automation.AutomationElement.FromHandle(windowDialog.Hwnd).FindAll(System.Windows.Autom ation.TreeScope.Children
    , System.Windows.Automation.Condition.TrueCondition);
    foreach (System.Windows.Automation.AutomationElement element in amc)
    {
    // You can use "Save ", "Open", ''Cancel', or "Close" to find necessary button Or write your own enum
    if (element.Current.Name.Equals("Save"))
    {
    // if doesn't work try to increase sleep interval or write your own waitUntill method
    // WaitUntillButtonExsist(element,100);
    Thread.Sleep(1000);
    System.Windows.Automation.AutomationPattern[] pats = element.GetSupportedPatterns();
    foreach (System.Windows.Automation.AutomationPattern pat in pats)
    {
    // '10000' button click event id 
    if (pat.Id == 10000)
    {
    System.Windows.Automation.InvokePattern click = (System.Windows.Automation.InvokePattern)element.GetCurrentPattern(pat);
    click.Invoke();
    }
    }
    }
    }
    }
    
