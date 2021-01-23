    internal class UnsafeNativeMethods
    {
        public const uint SPI_GETSCREENREADER = 0x0046;
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, ref bool pvParam, uint fWinIni);
    }
    public static class ScreenReader
    {
        public static bool IsRunning
        {
			get
			{
				bool returnValue = false;
				if (!UnsafeNativeMethods.SystemParametersInfo(UnsafeNativeMethods.SPI_GETSCREENREADER, 0, ref returnValue, 0))
				{
					throw new Win32Exception(Marshal.GetLastWin32Error(), "error calling SystemParametersInfo");
				}
				return returnValue;
			}
        }
    }
