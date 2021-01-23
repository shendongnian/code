    class Program
    {
    
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_Open(short intDeviceNumber, ref int lngHandle);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_Close(int lngHandle);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_SetDivisor(int lngHandle, int div);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_Read(int lngHandle, string lpszBuffer, int lngBufferSize, ref int lngBytesReturned);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_Write(int lngHandle, string lpszBuffer, int lngBufferSize, ref int lngBytesWritten);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_Write(int lngHandle, IntPtr lpBuffer, int lngBufferSize, ref int lngBytesWritten);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_SetBaudRate(int lngHandle, int lngBaudRate);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_SetDataCharacteristics(int lngHandle, byte byWordLength, byte byStopBits, byte byParity);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_SetFlowControl(int lngHandle, short intFlowControl, byte byXonChar, byte byXoffChar);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_ResetDevice(int lngHandle);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_SetDtr(int lngHandle);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_ClrDtr(int lngHandle);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_SetRts(int lngHandle);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_ClrRts(int lngHandle);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_GetModemStatus(int lngHandle, ref int lngModemStatus);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_Purge(int lngHandle, int lngMask);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_GetStatus(int lngHandle, ref int lngRxBytes, ref int lngTxBytes, ref int lngEventsDWord);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_GetQueueStatus(int lngHandle, ref int lngRxBytes);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_GetEventStatus(int lngHandle, ref int lngEventsDWord);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_SetChars(int lngHandle, byte byEventChar, byte byEventCharEnabled, byte byErrorChar, byte byErrorCharEnabled);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_SetTimeouts(int lngHandle, int lngReadTimeout, int lngWriteTimeout);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_SetBreakOn(int lngHandle);
        [DllImport("FTD2XX.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int FT_SetBreakOff(int lngHandle);
        // FTDI Constants
        const short FT_OK = 0;
        const short FT_INVALID_HANDLE = 1;
        const short FT_DEVICE_NOT_FOUND = 2;
        const short FT_DEVICE_NOT_OPENED = 3;
        const short FT_IO_ERROR = 4;
        const short FT_INSUFFICIENT_RESOURCES = 5;
        // Word Lengths
        const byte FT_BITS_8 = 8;
        // Stop Bits
        const byte FT_STOP_BITS_2 = 2;
        // Parity
        const byte FT_PARITY_NONE = 0;
        // Flow Control
        const byte FT_FLOW_NONE = 0x0;
        // Purge rx and tx buffers
        const byte FT_PURGE_RX = 1;
        const byte FT_PURGE_TX = 2;
        public static int handle=0;
      
        public static byte[] buffer = new byte[4];  // can be up to 512, shorter is faster
        private static string lpszBuffer=""+ (char) 0 + (char) 64 + (char) 64+ (char) 0;
        static void Main(string[] args)
        {
            init();
        }
        public static string init()
        {
            short n = 0;
            // ==== ATTEMPT TO OPEN DEVICE ====
            if (FT_Open(n, ref handle) != FT_OK)
            {
                return "FTTD Not Found";
            }
            // ==== PREPARE DEVICE FOR DMX TRANSMISSION ====
            // reset the device
            if (FT_ResetDevice(handle) != FT_OK)
            {
                return "Failed To Reset Device!";
            }
            // get an ID from the widget from jumpers
         //   GetID(ref n);
            // set the baud rate
            if (FT_SetDivisor(handle, 12) != FT_OK)
            {
                return "Failed To Set Baud Rate!";
            }
            // shape the line
            if (FT_SetDataCharacteristics(handle, FT_BITS_8, FT_STOP_BITS_2, FT_PARITY_NONE) != FT_OK)
            {
                return "Failed To Set Data Characteristics!";
            }
            // no flow control
            if (FT_SetFlowControl(handle, FT_FLOW_NONE, 0, 0) != FT_OK)
            {
                return "Failed to set flow control!";
            }
            // set bus transiever to transmit enable
            if (FT_ClrRts(handle) != FT_OK)
            {
                return "Failed to set RS485 to send!";
            }
            // Clear TX & RX buffers
            if (FT_Purge(handle, FT_PURGE_TX) != FT_OK)
            {
                return "Failed to purge TX buffer!";
            }
            // empty buffers
            if (FT_Purge(handle, FT_PURGE_RX) != FT_OK)
            {
                return "Failed to purge RX buffer!";
            }
            setDmxValue(0, 0);   // should always be zero
            setDmxValue(1, 64);
            setDmxValue(2, 64);
            setDmxValue(3, 0);
            Thread thread = new Thread(new ThreadStart(writeDataThread));
            thread.Start();
            return "Ok";
        }
        // init
        public static void setDmxValue(int channel, byte value)
        {
            buffer[channel] = value;
            lpszBuffer="";
            for (int i = 0; i < buffer.Length; ++i)
            {
                lpszBuffer += (char)buffer[i];
            }
        }
        public static void writeDataThread()
        {
            bool done = false;
            string lpszBuffer= ""+(char) 0+(char)64+(char)64+(char)0;
            int lngBytesWritten=0;
            while (!done)
            {
                FT_SetBreakOn(handle);
                FT_SetBreakOff(handle);
                FT_Write(handle, lpszBuffer, buffer.Length, ref lngBytesWritten);
                System.Threading.Thread.Sleep(50);
            }
        }
    }
}
