    static void Main(string[] args)
    {
        // you can find the value of this guid using SDK's "inspect" tool, hovering over the power icon.
        var SCAID_Power = new Guid("7820ae75-23e3-4229-82c1-e41cb67d5b9c");
        var power = EnumNotificationIcons().FirstOrDefault(i => string.Compare(i.Current.AutomationId, SCAID_Power.ToString("B"), StringComparison.OrdinalIgnoreCase) == 0);
        if (power != null)
        {
            power.InvokeButton();
        }
    }
    public static IEnumerable<AutomationElement> EnumNotificationIcons()
    {
        var userArea = AutomationElement.RootElement.Find("User Promoted Notification Area");
        if (userArea != null)
        {
            foreach (var button in userArea.EnumChildButtons())
            {
                yield return button;
            }
            foreach (var button in userArea.GetTopLevelElement().Find("System Promoted Notification Area").EnumChildButtons())
            {
                yield return button;
            }
        }
        var chevron = AutomationElement.RootElement.Find("Notification Chevron");
        if (chevron != null && chevron.InvokeButton())
        {
            foreach (var button in AutomationElement.RootElement.Find("Overflow Notification Area").EnumChildButtons())
            {
                yield return button;
            }
        }
    }
    public static class AutomationHelpers
    {
        public static AutomationElement Find(this AutomationElement root, string name) => root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, name));
        public static IEnumerable<AutomationElement> EnumChildButtons(this AutomationElement parent) => parent == null ? Enumerable.Empty<AutomationElement>() : parent.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button)).Cast<AutomationElement>();
        static public AutomationElement GetTopLevelElement(this AutomationElement element)
        {
            AutomationElement parent;
            while ((parent = TreeWalker.ControlViewWalker.GetParent(element)) != AutomationElement.RootElement)
            {
                element = parent;
            }
            return element;
        }
        public static bool InvokeButton(this AutomationElement button)
        {
            var invokePattern = button.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            invokePattern?.Invoke();
            return invokePattern != null;
        }
    }
