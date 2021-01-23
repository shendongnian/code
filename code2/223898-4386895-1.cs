    [StructLayout(LayoutKind.Sequential)]
    private struct StSomeData
    {
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 15)]
        public string Data;
    
       [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 15)]
        public int[] Values;
    }
