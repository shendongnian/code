    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    namespace test_winform_app
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
            }
    
    [DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    [DllImport("user32.dll")]
    private static extern bool IsIconic(IntPtr hWnd);
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                Process yourProcess = Process.GetProcessesByName("notepad");
    
    Dictionary<IntPtr, string> windows = (Dictionary<IntPtr, string>)WindowEnumerator.GetOpenWindowsFromPID(yourProcess.Id);
    IntPtr mainWindowHandle = IntPtr.Zero;
    foreach (KeyValuePair<IntPtr, string> pair in windows)
    {
        if (pair.Value.ToUpperInvariant() == "Main Window Title")
        {
            mainWindowHandle = pair.Key;
            break;
        }
    }
    
    if (mainWindowHandle != IntPtr.Zero)
    {
        if (IsIconic(mainWindowHandle))
        {
            ShowWindow(mainWindowHandle, 9);
        }
        SetForegroundWindow(mainWindowHandle);
    }
            }
    
            delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);
            public static class WindowEnumerator
            {
                [DllImport("user32.dll", SetLastError = true)]
                private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
    
                [DllImport("USER32.DLL")]
                private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);
    
                [DllImport("USER32.DLL")]
                private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
    
                [DllImport("USER32.DLL")]
                private static extern int GetWindowTextLength(IntPtr hWnd);
    
                [DllImport("USER32.DLL")]
                private static extern bool IsWindowVisible(IntPtr hWnd);
    
                [DllImport("USER32.DLL")]
                private static extern IntPtr GetShellWindow();
    
                public static IDictionary<IntPtr, string> GetOpenWindowsFromPID(int processID)
                {
                    IntPtr hShellWindow = GetShellWindow();
                    Dictionary<IntPtr, string> dictWindows = new Dictionary<IntPtr, string>();
    
                    EnumWindows(delegate(IntPtr hWnd, int lParam)
                    {
                        if (hWnd == hShellWindow) return true;
                        if (!IsWindowVisible(hWnd)) return true;
    
                        int length = GetWindowTextLength(hWnd);
                        if (length == 0) return true;
    
                        uint windowPid;
                        GetWindowThreadProcessId(hWnd, out windowPid);
                        if (windowPid != processID) return true;
    
                        StringBuilder stringBuilder = new StringBuilder(length);
                        GetWindowText(hWnd, stringBuilder, length + 1);
                        dictWindows.Add(hWnd, stringBuilder.ToString());
                        return true;
                    }, 0);
    
                    return dictWindows;
                }
            }
        }
    }
