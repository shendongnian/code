    System.Windows.Automation.AutomationElementCollection bmc =  element.FindAll(System.Windows.Automation.TreeScope.Children,   System.Windows.Automation.Automation.ControlViewCondition);
    System.Windows.Automation.InvokePattern click1 =  (System.Windows.Automation.InvokePattern)bmc[0].GetCurrentPattern(System.Windows.Automation.Autom ationPattern.LookupById(10000));
    click1.Invoke();
    Thread.Sleep(10000);
    System.Windows.Automation.AutomationElementCollection main =  mainWindow.FindAll(System.Windows.Automation.TreeScope.Children
    ,System.Windows.Automation.Condition.TrueCondition);
    foreach (System.Windows.Automation.AutomationElement el in main)
    {
    if (el.Current.LocalizedControlType == "menu")
    {
    // first array element 'Save', second array element 'Save as', third second array element    'Save and open'
    System.Windows.Automation.InvokePattern clickMenu = (System.Windows.Automation.InvokePattern)
                        el.FindAll(System.Windows.Automation.TreeScope.Children,      System.Windows.Automation.Condition.TrueCondition)  [1].GetCurrentPattern(System.Windows.Automation.AutomationPattern.LookupById(10000));
                           clickMenu.Invoke();
    break;
    }
    }
   
