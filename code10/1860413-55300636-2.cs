    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;
...........................
    public void StartChrome()
    {
        var allScreens = Screen.AllScreens.ToList();
        var screenOfChoice = allScreens[1]; // repllace with your own logic
        var chromeProcess = new Process
        {
                StartInfo =
                {
                        Arguments = "https://www.google.com --new-window --start-fullscreen",
                        FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe",
                        WindowStyle = ProcessWindowStyle.Normal
                }
        };
        chromeProcess.Start();
        // Needed to move the the process.
        Thread.Sleep(1000);
        // setting the x value here can help you determmine which screen to move the process to
        // 0 will be the first screen, and the '.WorkingArea.Right' value to the previous screen's '.WorkingArea.Right' would change which 
        // screen to display it on.
        MoveWindow(chromeProcess.MainWindowHandle, screenOfChoice.WorkingArea.Right, screenOfChoice.WorkingArea.Top, screenOfChoice.WorkingArea.Width, screenOfChoice.WorkingArea.Height, false);
    }
    [DllImport("user32.dll", SetLastError = true)]
    internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
