    private const int WM_SCROLL = 276; // Horizontal scroll
    private const int WM_VSCROLL = 277; // Vertical scroll
    private const int SB_LINEUP = 0; // Scrolls one line up
    private const int SB_LINELEFT = 0;// Scrolls one cell left
    private const int SB_LINEDOWN = 1; // Scrolls one line down
    private const int SB_LINERIGHT = 1;// Scrolls one cell right
    private const int SB_PAGEUP = 2; // Scrolls one page up
    private const int SB_PAGELEFT = 2;// Scrolls one page left
    private const int SB_PAGEDOWN = 3; // Scrolls one page down
    private const int SB_PAGERIGTH = 3; // Scrolls one page right
    private const int SB_PAGETOP = 6; // Scrolls to the upper left
    private const int SB_LEFT = 6; // Scrolls to the left
    private const int SB_PAGEBOTTOM = 7; // Scrolls to the upper right
    private const int SB_RIGHT = 7; // Scrolls to the right
    private const int SB_ENDSCROLL = 8; // Ends scroll
    [DllImport("user32.dll",CharSet=CharSet.Auto)]
    private static extern int SendMessage(IntPtr hWnd, int wMsg,IntPtr wParam, IntPtr lParam);
    SendMessage(treeView.Handle, WM Scroll Message, (IntPtr) Scroll Command ,IntPtr.Zero);
