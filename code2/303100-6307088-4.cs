    using System;
    using System.IO;
    
    namespace ConsoleApplication1
    {
        class Class1
        {
            [System.Runtime.InteropServices.DllImport("user32.dll")]
            private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
            private const int SW_MINIMIZE = 6;
            private const int SW_MAXIMIZE = 3;
            private const int SW_RESTORE = 9;
            
            [STAThread]
            static void Main(string[] args)
            {
                IntPtr winHandle =
                    System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
                ShowWindow(winHandle, SW_MINIMIZE);
                System.Threading.Thread.Sleep(2000);
                ShowWindow(winHandle, SW_RESTORE);
            }
        }
    }
