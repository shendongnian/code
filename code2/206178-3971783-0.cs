    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    
    namespace StackOverflow.Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                var proc = Process.GetProcessesByName("notepad").FirstOrDefault();
                if (proc != null && proc.MainWindowHandle != IntPtr.Zero)
                        SetForegroundWindow(proc.MainWindowHandle);
            }
    
            [DllImport("user32")]
            private static extern bool SetForegroundWindow(IntPtr hwnd);
        }
    }
