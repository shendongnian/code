            Process p = Process.GetProcessesByName("ProjectWithButton").FirstOrDefault();
            if (p != null)
            {
                AutomationElement ele = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ProcessIdProperty, p.Id));
                if (ele != null)
                {
                    AutomationElement chk= ele.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.AutomationIdProperty, "chkToggle"));
                    TogglePattern toggle = chk.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                    System.Diagnostics.Debug.WriteLine(toggle.Current.ToggleState);
                    toggle.Toggle();
                }
            }
