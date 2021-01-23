    public const int TVIF_STATE = 0x8;
    public const int TVIS_STATEIMAGEMASK = 0xF000;
    public const int TV_FIRST= 0x1100;
    public const int  TVM_SETITEM = TV_FIRST + 63;
    public struct TVITEM
    {
        public int mask;
        public IntPtr hItem;
        public int state;
        public int stateMask;
        [MarshalAs(UnmanagedType.LPTStr)]
        public String lpszText;
        public int cchTextMax;
        public int iImage;
        public int iSelectedImage;
        public int cChildren;
        public IntPtr lParam;
    }
    [DllImport("user32.dll")]
    static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, 
