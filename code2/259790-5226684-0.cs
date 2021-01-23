    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    
    public delegate bool CallBack(IntPtr hWnd, IntPtr lParam);
    
    public class EnumTopLevelWindows {
    
        [DllImport("user32", SetLastError=true)]
        private static extern int EnumWindows(CallBack x, IntPtr y);
    
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);
    
        [DllImport("user32.dll", EntryPoint = "GetWindowLong", SetLastError = true)]
        private static extern IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex);
    
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowVisible(IntPtr hWnd);
    
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);
    
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
    
        public static string GetText(IntPtr hWnd)
        {
            // Allocate correct string length first
            int length = GetWindowTextLength(hWnd);
            StringBuilder sb = new StringBuilder(length + 1);
            GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }
    
        private const int GW_OWNER = 4;
        private const int GWL_STYLE = -16;
        private const int WS_EX_APPWINDOW = 0x00040000;
        
        public static void Main() 
        {
            CallBack myCallBack = new CallBack(EnumTopLevelWindows.Report);
            EnumWindows(myCallBack, IntPtr.Zero);
        }
    
        public static bool Report(IntPtr hWnd, IntPtr lParam)
        {
            if (GetWindow(hWnd, GW_OWNER) == IntPtr.Zero)
            {
                //window is not owned
                if (IsWindowVisible(hWnd))
                {
                    //window is visible
                    int style = GetWindowLongPtr(hWnd, GWL_STYLE).ToInt32();
                    if ((style & WS_EX_APPWINDOW) == WS_EX_APPWINDOW)
                    {
                        //window has WS_EX_APPWINDOW style
                        Console.WriteLine(GetText(hWnd));
                    }
                }
            }
            return true;
        }
    }
