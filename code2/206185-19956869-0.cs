    IntPtr wbHandle = Win32.FindWindowEx(this.wbMain.Handle, IntPtr.Zero, "Shell Embedding", String.Empty);
    wbHandle = Win32.FindWindowEx(wbHandle, IntPtr.Zero, "Shell DocObject View", String.Empty);
    wbHandle = Win32.FindWindowEx(wbHandle, IntPtr.Zero, "Internet Explorer_Server", String.Empty);
    WbInternal wb = new WbInternal(wbHandle);
    class WbInternal : NativeWindow
        {
            public WbInternal(IntPtr handle)
            {
                this.AssignHandle(handle);
            }
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_MOUSEWHEEL)
                {
                    if (((int)m.WParam & 0x00FF) == MK_SHIFT)
                    {
                        return;
                    }
                }
                base.WndProc(ref m);
            }
        }
