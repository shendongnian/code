        /// <summary>
        /// TRUE if the process is running under WOW64. That is if it is a 32 bit process running on 64 bit Windows.
        /// If the process is running under 32-bit Windows, the value is set to FALSE. 
        /// If the process is a 64-bit application running under 64-bit Windows, the value is also set to FALSE.
        /// </summary>
        [DllImport( "kernel32.dll" )]
        static extern bool IsWow64Process( System.IntPtr aProcessHandle, out bool lpSystemInfo );
        
        /// <summary>
        /// Indicates if the process is 32 or 64 bit.
        /// </summary>
        /// <param name="aProcessHandle">process to query</param>
        /// <returns>true: process is 64 bit; false: process is 32 bit</returns>
        public static bool Is64BitProcess( System.IntPtr aProcessHandle )
        {
            bool lIs64BitProcess = false;
            if ( System.Environment.Is64BitOperatingSystem ) {
                IsWow64Process( aProcessHandle, out lIs64BitProcess );
            }
            return lIs64BitProcess;
        }
