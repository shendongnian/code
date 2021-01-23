    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
    public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, ref COPYDATASTRUCT lParam);
    public struct COPYDATASTRUCT {
      public int cbData;
      public IntPtr dwData;
      [MarshalAs(UnmanagedType.LPStr)] public string lpData;
    }
    var cds = new Win32.COPYDATASTRUCT {
                                               dwData = new IntPtr(3),
                                               cbData = str.Length + 1,
                                               lpData = str
                                             };
    Win32.SendMessage(ftprush, Win32.WM_COPYDATA, IntPtr.Zero, ref cds);
