    internal const int WM_NCHITTEST = 0x84;
    internal const int HT_CLIENT    = 0x01;
    internal const int HT_CAPTION   = 0x02;
    [DllImport("user32.dll")]
    internal static extern IntPtr DefWindowProc(IntPtr hWnd, int uMsg,
        IntPtr wParam, IntPtr lParam);
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
                            return;
                        }
                        m.Result = IntPtr.Zero;
                        return;
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
