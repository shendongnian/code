    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]    
    private struct LVCOLUMN    
    {        
        public Int32 mask;        
        public Int32 cx;        
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]
        public string pszText;
        public IntPtr hbm;
        public Int32 cchTextMax;
        public Int32 fmt;
        public Int32 iSubItem;
        public Int32 iImage;
        public Int32 iOrder;
    }
