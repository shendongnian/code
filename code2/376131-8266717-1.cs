     using System;
     using System.Collections.Generic;
     using System.Linq;
     using System.Text;
     using System.Windows;
     using System.Windows.Controls;
     using System.Windows.Data;
     using System.Windows.Documents;
     using System.Windows.Input;
     using System.Windows.Media;
     using System.Windows.Media.Imaging;
     using System.Windows.Navigation;
     using System.Windows.Shapes;
     using System.Runtime.InteropServices;
     using System.Windows.Interop;
     using System.IO;
     using System.Windows.Forms;
     namespace WpfApplication6
     {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }
        public static void LeftClick(int X, int Y)
        {
            System.Windows.Forms.Cursor.Position = new System.Drawing.Point(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y);
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
        }
        public static void LeftClickRelease(int X, int Y)
        {
            System.Windows.Forms.Cursor.Position = new System.Drawing.Point(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
        } 
        
        
        
        static class NativeMethods
        {
            [DllImport("user32.dll")]
            public static extern IntPtr WindowFromPoint(POINT point);
            [DllImport("user32.dll")]
            public static extern IntPtr GetParent(IntPtr hWnd);
            [DllImport("user32.dll")]
            public static extern bool GetCursorPos(ref POINT lpPoint);
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        public static Window GetWindowFromPoint(Point point)
        {
            var hwnd = NativeMethods.WindowFromPoint(new POINT((int)point.X, (int)point.Y));
            if (hwnd == IntPtr.Zero) return null;
            var p = NativeMethods.GetParent(hwnd);
            while (p != IntPtr.Zero)
            {
                hwnd = p;
                p = NativeMethods.GetParent(hwnd);
            }
            foreach (Window w in System.Windows.Application.Current.Windows)
            {
                if (w.IsVisible)
                {
                    var helper = new WindowInteropHelper(w);
                    if (helper.Handle == hwnd) return w;
                }
            }
            return null;
        }
        public static Window GetWindowFromMousePosition()
        {
            POINT p = new POINT();
            NativeMethods.GetCursorPos(ref p);
            return GetWindowFromPoint(new Point(p.x, p.y));
        }
       
        public MainWindow()
        {
           
            
            InitializeComponent();
            if (GetWindowFromMousePosition() != null)
            {
                LeftClick(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y);
                // mouse cursor is over window
            }
            else
            {
                LeftClickRelease(System.Windows.Forms.Cursor.Position.X, System.Windows.Forms.Cursor.Position.Y);
                    // mouse cursor is somewhere else
            }
        }
    }
}
