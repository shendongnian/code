    using System.Runtime.InteropServices;
    
    
    namespace ConsoleImageWorker
    {
        public static class Mouse
        {
    
            [DllImport("user32.dll")]
            static extern bool SetCursorPos(int X, int Y);
            
            public static void SetCursorPosition(int x, int y)
            {
                SetCursorPos(x, y);
            }
        }
    }
