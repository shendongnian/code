    [StructLayout(LayoutKind.Sequential)]
    private struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }
    private const int WM_NCHITTEST     = 0x0084;
    private const int WM_NCRBUTTONDOWN = 0x00A4;
    private const int WM_SYSCOMMAND    = 0x0112;
    private const int HT_CLIENT        = 0x01;
    private const int HT_CAPTION       = 0x02;
    private const int TPM_RIGHTBUTTON  = 0x0002;
    private const int TPM_RETURNCMD    = 0x0100;
    [DllImport("user32.dll")]
    private static extern IntPtr DefWindowProc(IntPtr hWnd, int uMsg,
        IntPtr wParam, IntPtr lParam);
    [DllImport("user32.dll")]
    private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
    [DllImport("user32.dll")]
    private static extern int TrackPopupMenu(int hMenu, int wFlags, int x, int y,
        int nReserved, int hwnd, ref RECT lprc);
    [DllImport("user32.dll")]
    private static extern int PostMessage(int hWnd, int Msg, int wParam,
        int lParam);
    protected override void WndProc(ref Message m)
    {
        if (!DesignMode)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    if (DefWindowProc(Handle, m.Msg, m.WParam, m.LParam).ToInt32()
                        == HT_CLIENT)
                    {
                        if (MouseInGlassArea())
                        {
                            m.Result = (IntPtr)HT_CAPTION;
                        }
                        else
                        {
                            m.Result = IntPtr.Zero;
                        }
                        return;
                    }
                    break;
                case WM_NCRBUTTONDOWN:
                    Point p = PointToClient(Cursor.Position);
                    if (p.X > 0 && p.X < ClientRectangle.Width
                        && p.Y > 0 && p.Y < ClientRectangle.Height)
                    {
                        IntPtr menuHandle = GetSystemMenu(Handle, false);
                        RECT rect = new RECT();
                        int menuItem = TrackPopupMenu(menuHandle.ToInt32(),
                            TPM_RIGHTBUTTON | TPM_RETURNCMD,
                            Cursor.Position.X, Cursor.Position.Y, 0,
                            Handle.ToInt32(), ref rect);
                        if (menuItem != 0)
                        {
                            PostMessage(Handle.ToInt32(), WM_SYSCOMMAND,
                                menuItem, 0);
                        }
                    }
                    break;
            }
        }
        base.WndProc(ref m);
    }
    private bool MouseInGlassArea()
    {
        if (_glassPadding.Left == -1 || _glassPadding.Right == -1
            || _glassPadding.Top == -1 || _glassPadding.Bottom == -1)
        {
            return true;
        }
        else
        {
            Point p = PointToClient(Cursor.Position);
            return (p.X < _glassPadding.Left
                || p.X > ClientRectangle.Width - _glassPadding.Right
                || p.Y < _glassPadding.Top
                || p.Y > ClientRectangle.Height - _glassPadding.Bottom);
        }
    }
