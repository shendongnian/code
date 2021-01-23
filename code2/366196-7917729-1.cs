    //...
    Point point = WinAPIHelper.GetPoint(msg.LParam);
    //...
    static class WinAPIHelper {
        public static Point GetPoint(IntPtr lParam) {
            return new Point(GetInt(lParam));
        }
        public static MouseButtons GetButtons(IntPtr wParam) {
            MouseButtons buttons = MouseButtons.None;
            int btns = GetInt(wParam);
            if((btns & MK_LBUTTON) != 0) buttons |= MouseButtons.Left;
            if((btns & MK_RBUTTON) != 0) buttons |= MouseButtons.Right;
            return buttons;
        }
        static int GetInt(IntPtr ptr) {
            return IntPtr.Size == 8 ? unchecked((int)ptr.ToInt64()) : ptr.ToInt32();
        }
        const int MK_LBUTTON = 1;
        const int MK_RBUTTON = 2;
    }
