    public class Win32
        { 
            [DllImport("User32.Dll")]
            public static extern long SetCursorPos(int x, int y);
    
            [DllImport("User32.Dll")]
            public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);
    
            [StructLayout(LayoutKind.Sequential)]
            public struct POINT
            {
                public int x;
                public int y;
            }
        }
