    class User32
     { 
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
    
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);
    
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, 
                                       uint dx, 
                                       uint dy, 
                                       uint dwData,
                                       int dwExtraInfo);
        
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, 
                                       uint dx, 
                                       uint dy, 
                                       uint dwData,
                                       UIntPtr dwExtraInfo);
    }
    
    class Program
    {
         static void Main()
         {
             User32.SetCursorPos(25, 153);
             User32.mouse_event((uint)User32.MouseEventFlags.LEFTDOWN, 25, 153, 0, 0);
             User32.mouse_event((uint)User32.MouseEventFlags.LEFTUP, 25, 153, 0, 0);
         }
    }
