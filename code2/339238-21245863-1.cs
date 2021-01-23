         public void SendClick(WMessages type, Point pos)
    {
        switch(type)
        {
            case WMessages.WM_LBUTTONDOWN:
                PostMessage(new HandleRef(null, this.process.MainWindowHandle),
                    (UInt32)WMessages.WM_LBUTTONDOWN, (IntPtr)0x1,
                    (IntPtr)((pos.Y << 16) | (pos.X & 0xFFFF)));
                return;
            case WMessages.WM_LBUTTONUP:
                PostMessage(new HandleRef(null, this.process.MainWindowHandle),
                    (UInt32)WMessages.WM_LBUTTONDOWN, (IntPtr)0x1, // <--(2) but you are telling to do WM_LBUTTONDOWN
                    (IntPtr)((pos.Y << 16) | (pos.X & 0xFFFF)));
                return;
            default:
                return;
        }
    }
    
    SendClick(WMessages.WM_LBUTTONDOWN, Cursor.Position);
    SendClick(WMessages.WM_LBUTTONUP, Cursor.Position); // <--(1) you are sending WM_LBUTTONUP
