    internal static class Utilities
    {
        [DllImport("user32.dll")]
        internal extern static int SetWindowLong(IntPtr hwnd, int index, int value);
        
        [DllImport("user32.dll")]
        internal extern static int GetWindowLong(IntPtr hwnd, int index);
        
        internal static void HideMinimizeAndMaximizeButtons(IntPtr hwnd)
        {
            const int GWL_STYLE = -16;
            const long WS_MINIMIZEBOX = 0x00020000L;
            const long WS_MAXIMIZEBOX = 0x00010000L;
        
            long value = GetWindowLong(hwnd, GWL_STYLE);
        
            SetWindowLong(hwnd, GWL_STYLE, (int)(value & ~WS_MINIMIZEBOX & ~WS_MAXIMIZEBOX));    // -131073 & -65537));
        
        }
    }
