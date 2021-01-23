    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }
    
            [DllImport("user32.dll", SetLastError = true)]
            static extern bool GetWindowRect(IntPtr hWnd, ref RECT Rect);
    
            [DllImport("user32.dll", SetLastError = true)]
            static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int Width, int Height, bool Repaint);
    
            static void Main(string[] args)
            {
                Process[] processes = Process.GetProcessesByName("notepad");
                foreach (Process p in processes)
                {
                    IntPtr handle = p.MainWindowHandle;
                    RECT Rect = new RECT();
                    if (GetWindowRect(handle, ref Rect))
                        MoveWindow(handle, Rect.left, Rect.right, Rect.right-Rect.left, Rect.bottom-Rect.top + 50, true);
                }
            }
        }
    }
