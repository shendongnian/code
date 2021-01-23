    public static void ConfirmDialogIE9(this Browser browser)
        {
            browser.ShowWindow(NativeMethods.WindowShowStyle.ShowMaximized);
            Thread.Sleep(2000);
            System.Windows.Automation.TreeWalker trw = new System.Windows.Automation.TreeWalker(System.Windows.Automation.Condition.TrueCondition);
            System.Windows.Automation.AutomationElement mainWindow = trw.GetParent(System.Windows.Automation.AutomationElement.FromHandle(browser.hWnd));
            System.Windows.Automation.AutomationElementCollection main = mainWindow.FindAll(System.Windows.Automation.TreeScope.Children
           , System.Windows.Automation.Condition.TrueCondition);
            foreach (System.Windows.Automation.AutomationElement element in main)
            {
                if (element.Current.Name.Equals("VIIS - Windows Internet Explorer") && element.Current.LocalizedControlType == "pane")
                {
                    System.Windows.Automation.AutomationElement DialogBox = trw.GetFirstChild(element);
                    DialogBox.SetFocus();
                    System.Windows.Automation.InvokePattern clickOk = (System.Windows.Automation.InvokePattern)
                    DialogBox.FindAll(System.Windows.Automation.TreeScope.Children, System.Windows.Automation.Condition.TrueCondition)[0].GetCurrentPattern(System.Windows.Automation.AutomationPattern.LookupById(10000));
                    clickOk.Invoke();
                    Thread.Sleep(1000);
                    break;
                }
            }
