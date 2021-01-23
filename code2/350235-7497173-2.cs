    [StructLayout(LayoutKind.Sequential)]
    public class POINT 
    {
        public int x;
        public int y;
    }
    [StructLayout(LayoutKind.Sequential)]
    public class MouseHookStruct 
    {
        public POINT pt;
        public int hwnd;
        public int wHitTestCode;
        public int dwExtraInfo;
    }
    public static int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
    {          
        MouseHookStruct MyMouseHookStruct = (MouseHookStruct)
            Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
        // You can get the coördinates using the MyMouseHookStruct.
        // ...       
        return CallNextHookEx(hHook, nCode, wParam, lParam); 
    }
