    private void InsertTextIntoAutomationElement(AutomationElement element, string value) {
    	
    	object valuePattern = null;
    	
    	if (!element.TryGetCurrentPattern(ValuePattern.Pattern, out valuePattern)) {
    		element.SetFocus();
    		Thread.Sleep(100);
    
    		SendKeys.SendWait("^{HOME}");   // Move to start of control
    		SendKeys.SendWait("^+{END}");   // Select everything
    		SendKeys.SendWait("{DEL}");     // Delete selection
    		SendKeys.SendWait(value);
    	} else{
    		element.SetFocus();
    		((ValuePattern)valuePattern).SetValue(value);
    	}
    }
