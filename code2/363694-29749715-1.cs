    public static class MouseWheelHandlerForWinformsControl
    {
        private class MouseWheelMessageFilter : IMessageFilter
        {
            [DllImport("user32.dll")]
            private static extern IntPtr WindowFromPoint(Point pt);
            private readonly Control mCtrl;
            private readonly Action<MouseEventArgs> mOnMouseWheel;
            public MouseWheelMessageFilter(Control ctrl, Action<MouseEventArgs> onMouseWheel)
            {
                mCtrl = ctrl;
                mOnMouseWheel = onMouseWheel;
            }
            public bool PreFilterMessage(ref Message m)
            {
                // handle only mouse wheel messages
                if (m.Msg != 0x20a)
                    return false;
                Point mouseAbsolutePosition = new Point(m.LParam.ToInt32());
                Point mouseRelativePosition = mCtrl.PointToClient(mouseAbsolutePosition);
                IntPtr hControlUnderMouse = WindowFromPoint(mouseAbsolutePosition);
                Control controlUnderMouse = Control.FromHandle(hControlUnderMouse);
                if (controlUnderMouse != mCtrl)
                    return false;
                MouseButtons buttons = GetMouseButtons(m.WParam.ToInt32());
                int delta = m.WParam.ToInt32() >> 16;
                var e = new MouseEventArgs(buttons, 0, mouseRelativePosition.X, mouseRelativePosition.Y, delta);
                mOnMouseWheel(e);
                return true;
            }
            private static MouseButtons GetMouseButtons(int wParam)
            {
                MouseButtons buttons = MouseButtons.None;
                
                if(HasFlag(wParam, 0x0001)) buttons |= MouseButtons.Left;
                if(HasFlag(wParam, 0x0010)) buttons |= MouseButtons.Middle;
                if(HasFlag(wParam, 0x0002)) buttons |= MouseButtons.Right;
                if(HasFlag(wParam, 0x0020)) buttons |= MouseButtons.XButton1;
                if(HasFlag(wParam, 0x0040)) buttons |= MouseButtons.XButton2;
                           
                return buttons;
            }
            private static bool HasFlag(int input, int flag)
            {
                return (input & flag) == flag;
            }
        }
        public static void MemorySafeAdd(Control ctrl, Action<MouseEventArgs> onMouseWheel)
        {
            if (ctrl == null || onMouseWheel == null)
                throw new ArgumentNullException();
            var filter = new MouseWheelMessageFilter(ctrl, onMouseWheel);
            Application.AddMessageFilter(filter);
            ctrl.Disposed += (s, e) => Application.RemoveMessageFilter(filter);
        }
    }
