    using System.Windows.Automation;
        (AutomationElement.RootElement
            .FindFirst(TreeScope.Descendants,
                       new PropertyCondition(AutomationElement.NameProperty, "Save As"))
            .FindFirst(TreeScope.Descendants,
                       new AndCondition(
                           new PropertyCondition(AutomationElement.NameProperty,
                                                 "File name:"),
                           new PropertyCondition(AutomationElement.ControlTypeProperty,
                                                 ControlType.Edit)))
            .GetCurrentPattern(ValuePattern.Pattern) as ValuePattern).SetValue("Booga");
