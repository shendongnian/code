    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Interop;
    
    namespace Project
    {
        public partial class MainWindow : Window
        {
            private const int WH_MOUSE_LL = 14;
            private const int WM_MOUSEWHEEL = 0x020A;
            private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
    
            private IntPtr _handle;
    
            public MainWindow()
            {
                InitializeComponent();
    
                _handle = new WindowInteropHelper(this).Handle;
                SetWindowsHookEx(WH_MOUSE_LL, MouseChanged, _handle, 0);
    
                ScrollViewer.PreviewMouseWheel += ScrollViewer_MouseWheel;
                Unloaded += MainWindow_Unloaded;
            }
    
            private void MainWindow_Unloaded(object sender, RoutedEventArgs e)
            {
                UnhookWindowsHookEx(_handle);
            }
    
            private void ScrollViewer_MouseWheel(object sender, MouseWheelEventArgs e)
            {
                e.Handled = true;
            }
    
            private IntPtr MouseChanged(int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (ScrollViewer.IsMouseOver && WM_MOUSEWHEEL == (int)wParam)
                {
                    MouseData mouseData = (MouseData)Marshal.PtrToStructure(lParam, typeof(MouseData));
                    ScrollViewer.ScrollToVerticalOffset(ScrollViewer.VerticalOffset - mouseData.Z / 200000.0);
                }
                return CallNextHookEx(_handle, nCode, wParam, lParam);
            }
    
            [StructLayout(LayoutKind.Sequential)]
            private struct MouseData
            {
                public int X;
                public int Y;
                public int Z;
            }
    
            [DllImport("user32.dll")]
            private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);
    
            [DllImport("user32.dll")]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);
    
            [DllImport("user32.dll")]
            private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        }
    }
