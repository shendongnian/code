    public struct COPYDATASTRUCT
    {
        public IntPtr dwData;
        public UInt32 cbData;
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpData;
    }  
    [DllImport("User32.dll", EntryPoint = "SendMessage")]
            public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);
    IntPtr result;
                
                byte[] sarr = System.Text.Encoding.Default.GetBytes(sendMsg);
                int len = sarr.Length;
                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)3;
                cds.lpData = sendMsg;
                cds.cbData = (UInt32)len + 1;
                result = SendMessage(hwndTarget, WM_COPYDATA, 0, ref cds);
