    public class DataGridViewEx : DataGridView
        {
            private const int WM_HSCROLL = 0x0114;
            private const int WM_VSCROLL = 0x0115;
            private const int WM_MOUSEWHEEL = 0x020A;
    
            public event ScrollEventHandler ScrollEvent;
            const int SB_HORZ = 0;
            const int SB_VERT = 1;
            public int ScrollValue;
            [DllImport("User32.dll")]
            static extern int GetScrollPos(IntPtr hWnd, int nBar);
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                if (m.Msg == WM_VSCROLL ||
                    m.Msg == WM_MOUSEWHEEL)
                    if (ScrollEvent != null)
                    {
                        this.ScrollValue = GetScrollPos(Handle, SB_VERT);
                        ScrollEventArgs e = new ScrollEventArgs(ScrollEventType.ThumbTrack, ScrollValue);
                        this.ScrollEvent(this, e);
                    }            
            }
        }
