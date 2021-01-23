    //use this class with a timer
    //or hooking the window shouldn't be hard either
    //this is the easier way to do it though
    using System;
    using System.Runtime.InteropServices;
  
    public static class WindowState
    {
        [DllImport("user32")]
        private static extern int IsWindowEnabled(int hWnd);
        
        [DllImport("user32")]
        private static extern int IsWindowVisible(int hWnd);
        [DllImport("user32")]
        private static extern int IsZoomed(int hWnd);
        
        [DllImport("user32")]
        private static extern int IsIconic(int hWnd);
        public static bool IsMaximized(int hWnd) 
        {
            if (IsZoomed(hWnd) == 0)
                return false;
            else
                return true;
        }
        public static bool IsMinimized(int hWnd)
        {
            if (IsIconic(hWnd) == 0)
                return false;
            else
                return true;
        }
        public static bool IsEnabled(int hWnd)
        {
            if (IsWindowEnabled(hWnd) == 0)
                return false;
            else
                return true;
        }
        public static bool IsVisible(int hWnd)
        {
            if (IsWindowVisible(hWnd) == 0)
                return false;
            else
                return true;
        }
    }
