    // 1. Change the function to call the Unicode variant, where applicable.
    // 2. Ask the marshaller to alert you to any errors that occur.
    // 3. Change the parameter types to make marshaling easier. 
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SystemParametersInfo(
    	                                            int uiAction,
    	                                            int uiParam,
    	                                            ref RECT pvParam,
    	                                            int fWinIni);
    private const Int32 SPIF_SENDWININICHANGE = 2;
    private const Int32 SPIF_UPDATEINIFILE = 1;
    private const Int32 SPIF_change = SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE;
    private const Int32 SPI_SETWORKAREA = 47;
    private const Int32 SPI_GETWORKAREA = 48;
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public Int32 Left;
        public Int32 Top;	// top is before right in the native struct
        public Int32 Right;
        public Int32 Bottom;
    }
    private static bool SetWorkspace(RECT rect)
    {
       // Since you've declared the P/Invoke function correctly, you don't need to
       // do the marshaling yourself manually. The .NET FW will take care of it.
       
       bool result = SystemParametersInfo(SPI_SETWORKAREA,
                                          IntPtr.Zero,
                                          ref RECT,
                                          SPIF_change);
       if (!result)
       {
           // Find out the error code
           MessageBox.Show("The last error was: " +
                           Marshal.GetLastWin32Error().ToString());
       }
       
       return result;
    }
    
