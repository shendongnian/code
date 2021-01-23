    class UpDownControl : Control
    {
        public event EventHandler UpClick;
        public event EventHandler DownClick;
    
        protected virtual void OnUpClick(EventArgs e)
        {
            EventHandler handler = UpClick;
            if (handler != null)
                handler(this, e);
        }
    
        protected virtual void OnDownClick(EventArgs e)
        {
            EventHandler handler = DownClick;
            if (handler != null)
                handler(this, e);
        }
    
        public UpDownControl()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, false);
            this.CreateParams.ClassName = "msctls_updown32";
        }
    
        protected override void CreateHandle()
        {
            if (!base.RecreatingHandle)
            {
                INITCOMMONCONTROLSEX icc = new INITCOMMONCONTROLSEX();
                icc.dwICC = ICC_UPDOWN_CLASS;
                InitCommonControlsEx(icc);
            }
            base.CreateHandle();
        }
    
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x2000 + 0x004E) // <reflected> WM_NOTIFY
            {
                uint nmhdrCode = (uint)Marshal.ReadInt32(m.LParam, IntPtr.Size * 2 + 0);
                if (nmhdrCode == UDN_DELTAPOS)
                {
                    int iPos = Marshal.ReadInt32(m.LParam, IntPtr.Size * 2 + 4);
                    int iDelta = Marshal.ReadInt32(m.LParam, IntPtr.Size * 2 + 8);
    
                    if (iDelta > 0)
                        OnDownClick(EventArgs.Empty);
                    else if (iDelta < 0)
                        OnUpClick(EventArgs.Empty);
                }
            }
            base.WndProc(ref m);
        }
    
        const int ICC_UPDOWN_CLASS = 0x00000010;
        const uint UDN_FIRST = unchecked(0U - 721U);
        const uint UDN_DELTAPOS = unchecked(UDN_FIRST - 1);
    
        [DllImport("comctl32.dll")]
        static extern bool InitCommonControlsEx(INITCOMMONCONTROLSEX icc);
     
        [StructLayout(LayoutKind.Sequential)]
        class INITCOMMONCONTROLSEX
        {
            public int dwSize = 8;
            public int dwICC;
        }
    }
