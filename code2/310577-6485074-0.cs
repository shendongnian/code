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
                public int X;
                public int Y;
                public int Width;
                public int Height;
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
                        MoveWindow(handle, Rect.X, Rect.Y, Rect.Width + 50, Rect.Height, true);
                }
            }
        }
    }
