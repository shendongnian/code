    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace centrewindow
    {
        public partial class Form1 : Form
        {
            public struct RECT
            {
                public int Left;        // x position of upper-left corner
                public int Top;         // y position of upper-left corner
                public int Right;       // x position of lower-right corner
                public int Bottom;      // y position of lower-right corner
            }
    
            [DllImport("user32.dll")]
            public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);
    
            [DllImport("user32.dll")]
            public static extern bool GetWindowRect(HandleRef hwnd, out RECT lpRect);
            
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                CentreWindow(Handle, GetMonitorDimensions());
            }
    
            private void CentreWindow(IntPtr handle, Size monitorDimensions)
            {
                RECT rect;
                GetWindowRect(new HandleRef(this, handle), out rect);
                
                var x1Pos = monitorDimensions.Width/2 - (rect.Right - rect.Left)/2;
                var x2Pos = rect.Right - rect.Left;
                var y1Pos = monitorDimensions.Height/2 - (rect.Bottom - rect.Top)/2;
                var y2Pos = rect.Bottom - rect.Top;
    
                SetWindowPos(handle, 0, x1Pos, y1Pos, x2Pos, y2Pos, 0);
            }
    
            private Size GetMonitorDimensions()
            {
                return SystemInformation.PrimaryMonitorSize;
            }
        }
    }
