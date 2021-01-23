    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, IntPtr lParam);
    private const uint WM_SETICON = 0x80u;
    private const int ICON_SMALL = 0;
    private const int ICON_BIG = 1;
    public MyForm()
    {
        InitializeComponent();
        SendMessage(this.Handle, WM_SETICON, ICON_SMALL, Properties.Resources.IconSmall.Handle);
        SendMessage(this.Handle, WM_SETICON, ICON_BIG, Properties.Resources.IconBig.Handle);
    }
