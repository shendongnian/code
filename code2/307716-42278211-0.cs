    public class SimpleSerialPort : IDisposable
    {
        private const uint GenericRead = 0x80000000;
        private const uint GenericWrite = 0x40000000;
        private const int OpenExisting = 3;
        private const uint Setdtr = 5; // Set DTR high
        private FileStream _fileStream;
        public void Close()
        {
            Dispose();
        }
        public int WriteTimeout { get; set; }
        public SafeFileHandle Handle { get; private set; }
        public void Open(string portName, uint baudrate)
        {
            // Check if port can be found
            bool isValid =
                SerialPort.GetPortNames()
                    .Any(x => String.Compare(x, portName, StringComparison.OrdinalIgnoreCase) == 0);
            if (!isValid)
            {
                throw new IOException(string.Format("{0} port was not found", portName));
            }
            string port = @"\\.\" + portName;
            Handle = CreateFile(port, GenericRead | GenericWrite, 0, IntPtr.Zero, OpenExisting, 0, IntPtr.Zero);
            if (Handle.IsInvalid)
            {
                throw new IOException(string.Format("{0} port is already open", portName));
            }
            var dcb = new Dcb();
            // first get the current dcb structure setup
            if (GetCommState(Handle, ref dcb) == false)
            {
                throw new IOException(string.Format("GetCommState error {0}", portName));
            }
            dcb.BaudRate = baudrate;
            dcb.ByteSize = 8;
            dcb.Flags = 129;
            dcb.XoffChar = 0;
            dcb.XonChar = 0;
            /* Apply the settings */
            if (SetCommState(Handle, ref dcb) == false)
            {
                throw new IOException(string.Format("SetCommState error {0}", portName));
            }
            /* Set DTR, some boards needs a DTR = 1 level */
            if (EscapeCommFunction(Handle, Setdtr) == false)
            {
                throw new IOException(string.Format("EscapeCommFunction error {0}", portName));
            }
            // Write default timeouts 
            var cto = new Commtimeouts
            {
                ReadTotalTimeoutConstant = 500,
                ReadTotalTimeoutMultiplier = 0,
                ReadIntervalTimeout = 10,
                WriteTotalTimeoutConstant = WriteTimeout,
                WriteTotalTimeoutMultiplier = 0
            };
            if (SetCommTimeouts(Handle, ref cto) == false)
            {
                throw new IOException(string.Format("SetCommTimeouts error {0}", portName));
            }
            // Create filestream 
            _fileStream = new FileStream(Handle, FileAccess.ReadWrite, 32, false);
        }
        public void Write(byte[] bytes)
        {
            _fileStream.Write(bytes, 0, bytes.Length);
        }
        public void Read(byte[] readArray)
        {
            for (int read = 0; read < readArray.Length;)
            {
                read += _fileStream.Read(readArray, read, readArray.Length - read);
            }
        }
        public byte ReadByte()
        {
            byte[] readsBytes = new byte[1];
            Read(readsBytes);
            return readsBytes[0];
        }
        public void Dispose()
        {
            if (Handle != null)
            {
                Handle.Dispose();
            }
            if (_fileStream != null)
            {
                _fileStream.Dispose();
            }
            _fileStream = null;
            Handle = null;
        }
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern SafeFileHandle CreateFile(string lpFileName, uint dwDesiredAccess, int dwShareMode,
            IntPtr securityAttrs, int dwCreationDisposition, int dwFlagsAndAttributes, IntPtr hTemplateFile);
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool GetCommState(
            SafeFileHandle hFile, // handle to communications device
            ref Dcb lpDcb // device-control block
            );
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool SetCommState(
            SafeFileHandle hFile, // handle to communications device
            ref Dcb lpDcb // device-control block
            );
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool EscapeCommFunction(
            SafeFileHandle hFile, // handle to communications device
            uint dwFunc
            );
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool SetCommTimeouts(
            SafeFileHandle hFile, // handle to comm device
            ref Commtimeouts lpCommTimeouts // time-out values
            );
        [StructLayout(LayoutKind.Sequential)]
        private struct Commtimeouts
        {
            public int ReadIntervalTimeout;
            public int ReadTotalTimeoutMultiplier;
            public int ReadTotalTimeoutConstant;
            public int WriteTotalTimeoutMultiplier;
            public int WriteTotalTimeoutConstant;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct Dcb
        {
            private readonly uint DCBlength;
            public uint BaudRate;
            public uint Flags;
            private readonly ushort WReserved;
            private readonly ushort XonLim;
            private readonly ushort XoffLim;
            public byte ByteSize;
            private readonly byte Parity;
            private readonly byte StopBits;
            public byte XonChar;
            public byte XoffChar;
            private readonly byte ErrorChar;
            private readonly byte EofChar;
            private readonly byte EvtChar;
            private readonly ushort WReserved1;
        }
    }
