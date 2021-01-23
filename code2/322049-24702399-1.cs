    [StructLayout(LayoutKind.Sequential)]
    public struct COPYDATASTRUCT : IDisposable
    {
        public IntPtr dwData;
        public int cbData;
        public IntPtr lpData;
        /// <summary>
        /// Only dispose COPYDATASTRUCT if you were the one who allocated it
        /// </summary>
        public void Dispose()
        {
            if (lpData != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(lpData);
                lpData = IntPtr.Zero;
                cbData = 0;
            }
        }
        public string AsAnsiString { get { return Marshal.PtrToStringAnsi(lpData, cbData); } }
        public string AsUnicodeString { get { return Marshal.PtrToStringUni(lpData); } }
        public static COPYDATASTRUCT CreateForString(int dwData, string value, bool Unicode = false)
        {
            var result = new COPYDATASTRUCT();
            result.dwData = (IntPtr)dwData;
            result.lpData = Unicode ? Marshal.StringToCoTaskMemUni(value) : Marshal.StringToCoTaskMemAnsi(value);
            result.cbData = value.Length + 1;
            return result;
        }
    }
