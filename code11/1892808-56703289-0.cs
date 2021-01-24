using System.Windows.Forms;
using System.Diagnostics;
using Vanara.PInvoke;
…
// Get all Internet Explorer processes with a window title 
Process[] ieProcs = Process.GetProcessesByName("iexplore")
    .Where(p => !string.IsNullOrEmpty(p.MainWindowTitle))
    .ToArray();
// Initialize a URL array to hold the active tab URL
string[] ieUrls = new string[ieProcs.Length];
for (int i = 0; i < ieProcs.Length; i++)
{
    Process proc = ieProcs[i];
    // Remember the initial window style of the process window
    User32_Gdi.WindowStyles initialWndStyles = (User32_Gdi.WindowStyles)User32_Gdi.GetWindowLongPtr(proc.MainWindowHandle, User32_Gdi.WindowLongFlags.GWL_STYLE);
    // Remember the initial foreground window
    IntPtr initialFgdWnd = (IntPtr)User32_Gdi.GetForegroundWindow();
    // Show the process window.
    // If it is minimized, it needs to be restored, if not, just show
    if (initialWndStyles.HasFlag(User32_Gdi.WindowStyles.WS_MINIMIZE))
    {
        User32_Gdi.ShowWindow(proc.MainWindowHandle, ShowWindowCommand.SW_RESTORE);
    }
    else
    {
        User32_Gdi.ShowWindow(proc.MainWindowHandle, ShowWindowCommand.SW_SHOW);
    }
    // Set the process window as the foreground window
    User32_Gdi.SetForegroundWindow(proc.MainWindowHandle);
    ieUrls[i] = null;
    // Remember the initial data on the clipboard and clear the clipboard
    IDataObject dataObject = Clipboard.GetDataObject();
    Clipboard.Clear();
    // Start a Stopwatch to timeout if no URL found
    Stopwatch sw = Stopwatch.StartNew();
    // Try to copy the active tab URL
    while (string.IsNullOrEmpty(ieUrls[i]) && sw.ElapsedMilliseconds < 1000)
    {
        // Send ALT+D
        SendKeys.SendWait("%(d)");
        SendKeys.Flush();
        // Send CRTL+C
        SendKeys.SendWait("^(c)");
        SendKeys.Flush();
        ieUrls[i] = Clipboard.GetText();
    }
    // Return the initial clipboard data to the clipboard
    Clipboard.SetDataObject(dataObject);
    // If the process window was initially minimized, minimize it
    if(initialWndStyles.HasFlag(User32_Gdi.WindowStyles.WS_MINIMIZE))
    {
        User32_Gdi.ShowWindow(proc.MainWindowHandle, ShowWindowCommand.SW_MINIMIZE);
    }
    // Return the initial foreground window to the foreground
    User32_Gdi.SetForegroundWindow(initialFgdWnd);
}
// Print the active tab URL's
for (int i = 0; i < ieUrls.Length; i++)
{
    Console.WriteLine(ieUrls[i]);
}
