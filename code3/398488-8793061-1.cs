    public static string GetText(IntPtr hwnd)
    {
      var editElement = AutomationElement.FromHandle(hwnd).
                        FindFirst(TreeScope.Subtree,
                                  new PropertyCondition(
                                         AutomationElement.ClassNameProperty, "Edit"));
      return (string)editElement.GetCurrentPropertyValue(AutomationElement.NameProperty);
    }
