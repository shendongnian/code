    public static class AutomationElementExtensions
        { 
            public static void InvokeControl(this AutomationElement element)
            {
                InvokePattern invokePattern = null;
    
                try
                {
                    invokePattern =
                        element.GetCurrentPattern(InvokePattern.Pattern)
                        as InvokePattern;
                }
                catch (ElementNotEnabledException)
                {
                    // Object is not enabled
                    return;
                }
                catch (InvalidOperationException)
                {
                    // object doesn't support the InvokePattern control pattern
                    return;
                }
    
                invokePattern.Invoke();
                Thread.Sleep(500);
            } 
    		
    		
            public static void SetSelectedComboBoxItem(this AutomationElement comboBox, string item)
            {
                AutomationPattern automationPatternFromElement = GetSpecifiedPattern(comboBox, "ExpandCollapsePatternIdentifiers.Pattern");
    
                ExpandCollapsePattern expandCollapsePattern = comboBox.GetCurrentPattern(automationPatternFromElement) as ExpandCollapsePattern;
    
                expandCollapsePattern.Expand();
    
    
    
                AutomationElement listItem = comboBox.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, item));
    
                InvokeControl(listItem); 
            }
    
            private static AutomationPattern GetSpecifiedPattern(AutomationElement element, string patternName)
            {
                AutomationPattern[] supportedPattern = element.GetSupportedPatterns();
    
                foreach (AutomationPattern pattern in supportedPattern)
                {
                    if (pattern.ProgrammaticName == patternName)
                        return pattern;
                }
    
                return null;
            }
    
    
        }
