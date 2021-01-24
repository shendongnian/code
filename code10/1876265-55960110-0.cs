    using System.Diagnostics;
    using System.IO;
    using System.Security.Permissions;
    using System.Windows.Automation;
    using System.Windows.Forms;
    static class Program
    {
        [STAThread]
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        static void Main(string[] args)
        {
            Automation.AddAutomationEventHandler(
                WindowPattern.WindowOpenedEvent, AutomationElement.RootElement,
                TreeScope.Subtree, (uiElm, evt) =>
                {
                    AutomationElement element = uiElm as AutomationElement;
                    if (element == null) return;
                    try 
                    {
                        if (element.Current.ProcessId == Process.GetCurrentProcess().Id)
                        {
                            IntPtr elmHandle = (IntPtr)element.Current.NativeWindowHandle;
                            Control form = Application.OpenForms.OfType<Control>()
                                .Where(f => (f.AccessibilityObject as Control.ControlAccessibleObject).Handle == elmHandle)
                                .FirstOrDefault();
                            string log = $"Name: {form?.Name ?? element.Current.AutomationId} " +
                                         $"Form title: {element.Current.Name}{Environment.NewLine}";
                            File.AppendAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "formLogger.txt"), log);
                        }
                    }
                    catch (ElementNotAvailableException) { /* May happen when Debugging => ignore or log */ }
                });
