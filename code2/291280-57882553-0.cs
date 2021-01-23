     public partial class OrganizationFilesListView : ListView
    {
        // Windows messages
        private const int WM_VSCROLL = 0x0115;
        private const int WM_MOUSEHWHEEL = 0x020E;
        private const int WM_MOUSEWHEEL = 0x020A;
        private const int WM_KEYDOWN = 0x0100;
        // ScrollBar types
        private const int SB_VERT = 1; // only for maximum vertical scroll position
        // ScrollBar interfaces
        private const int SIF_TRACKPOS = 0x10;
        private const int SIF_RANGE = 0x01;
        private const int SIF_POS = 0x04;
        private const int SIF_PAGE = 0x02;
        private const int SIF_ALL = SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS;
        // variable to force to run only once the event
        private bool runningOnMaximumBottomScroll = false;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            SCROLLINFO si = new SCROLLINFO();
            si.cbSize = (uint)Marshal.SizeOf(si);
            si.fMask = (uint)ScrollInfoMask.SIF_ALL;
            bool isMaximumButtomScroll = false;
            switch (m.Msg)
            {
                case WM_VSCROLL:
                    isMaximumButtomScroll = GetScrollInfo(m.HWnd, SB_VERT, ref si) ? (si.nPage + si.nPos) >= si.nMax : false;
                    if (isMaximumButtomScroll && !runningOnMaximumBottomScroll)
                    {
                        runningOnMaximumBottomScroll = true;
                        onMaximumBottomScroll(this, new ScrollEventArgs(ScrollEventType.EndScroll, GetScrollPos(this.Handle, SB_VERT)));
                        runningOnMaximumBottomScroll = false;
                    }
                    break;
                case WM_MOUSEHWHEEL:
                case WM_MOUSEWHEEL:
                    isMaximumButtomScroll = GetScrollInfo(m.HWnd, SB_VERT, ref si) ? (si.nPage + si.nPos) >= si.nMax : false;
                    bool isMouseWheelDown = m.Msg == WM_MOUSEWHEEL ? (int)m.WParam < 0 : (int)m.WParam > 0;
                    if (isMaximumButtomScroll && isMouseWheelDown && !runningOnMaximumBottomScroll)
                    {
                        runningOnMaximumBottomScroll = true;
                        onMaximumBottomScroll(this, new ScrollEventArgs(ScrollEventType.EndScroll, GetScrollPos(this.Handle, SB_VERT)));
                        runningOnMaximumBottomScroll = false;
                    }
                    break;
                case WM_KEYDOWN:
                    isMaximumButtomScroll = GetScrollInfo(m.HWnd, SB_VERT, ref si) ? (si.nPage + si.nPos) >= (si.nMax - 1) : false;
                    switch (m.WParam.ToInt32())
                    {
                        case (int)Keys.Down:
                        case (int)Keys.PageDown:
                        case (int)Keys.End:
                            if (isMaximumButtomScroll && !runningOnMaximumBottomScroll)
                            {
                                runningOnMaximumBottomScroll = true;
                                onMaximumBottomScroll(this, new ScrollEventArgs(ScrollEventType.EndScroll, GetScrollPos(this.Handle, SB_VERT)));
                                runningOnMaximumBottomScroll = false;
                            }
                            break;
                    }
                    break;
            }
        }
        public event ScrollEventHandler onMaximumBottomScroll;
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int GetScrollPos(IntPtr hWnd, int nBar);
        [Serializable, StructLayout(LayoutKind.Sequential)]
        struct SCROLLINFO
        {
            public uint cbSize;
            public uint fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }
        public enum ScrollInfoMask : uint
        {
            SIF_RANGE = 0x1,
            SIF_PAGE = 0x2,
            SIF_POS = 0x4,
            SIF_DISABLENOSCROLL = 0x8,
            SIF_TRACKPOS = 0x10,
            SIF_ALL = (SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS),
        }
    }
