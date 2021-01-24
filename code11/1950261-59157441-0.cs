    private const string BTN_CANCEL_NAME = "Cancel";
    private const string BTN_OK_NAME = "Ok";
    private static AutomationElement FindButton(AutomationElement window, string btnName)
    {
        var btnCondition = new AndCondition(new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
                                        new PropertyCondition(AutomationElement.NameProperty, btnName, PropertyConditionFlags.IgnoreCase));
    
        return window.FindFirst(TreeScope.Children, btnCondition);
    }
