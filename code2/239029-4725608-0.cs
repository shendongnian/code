    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    class Program {
        static void Main(string[] args) {
            var prc = Process.Start("notepad.exe");
            prc.WaitForInputIdle();
            bool ok = MoveWindow(prc.MainWindowHandle, 0, 0, 300, 200, false);
            if (!ok) throw new System.ComponentModel.Win32Exception();
        }
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int width, int height, bool repaint);
    }
