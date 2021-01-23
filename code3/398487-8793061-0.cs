    using System.Windows.Automation;
    public static string GetText(IntPtr hwnd)
    {
      IntPtr hwndEdit = FindWindowEx(hwnd, IntPtr.Zero, "Edit", null);
      return (string)AutomationElement.FromHandle(hwndEdit).
         GetCurrentPropertyValue(AutomationElement.NameProperty);
    }
