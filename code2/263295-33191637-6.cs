     public static string GetFirefoxUrl(Process process)
            {
                if (process == null)
                    throw new ArgumentNullException("process");
    
                if (process.MainWindowHandle == IntPtr.Zero)
                    return null;
    
                AutomationElement element = AutomationElement.FromHandle(process.MainWindowHandle);
                if (element == null)
                    return null;
                
           
                element = element.FindFirst(TreeScope.Subtree, 
                      new AndCondition(
                          new PropertyCondition(AutomationElement.NameProperty, "search or enter address", PropertyConditionFlags.IgnoreCase),
                          new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit)));
                            
    
                if (element == null)
                    return null;
    
                return ((ValuePattern)element.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
            }
