        #region Load C DLL
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ProgressCallback(IntPtr buffer, int length);
        [DllImport("mttty.dll")]
        static extern void ConnectToSerialPort([MarshalAs(UnmanagedType.FunctionPtr)] ProgressCallback telnetCallbackPointer,
            [MarshalAs(UnmanagedType.FunctionPtr)] ProgressCallback statusCallbackPointer,
            [MarshalAs(UnmanagedType.FunctionPtr)] ProgressCallback errorCallbackPointer);
        #endregion
        #region Callbacks 
        private void TelnetCallback(IntPtr unsafeBuffer, int length)
        {
            byte[] safeBuffer = new byte[length];
            Marshal.Copy(unsafeBuffer, safeBuffer, 0, length);
            Console.WriteLine(Encoding.UTF8.GetString(safeBuffer));
        }
        private void StatusCallback(IntPtr unsafeBuffer, int length)
        {
            byte[] safeBuffer = new byte[length];
            Marshal.Copy(unsafeBuffer, safeBuffer, 0, length);            
            Console.WriteLine("Status: "+Encoding.UTF8.GetString(safeBuffer));
        }
        private void ErrorCallback(IntPtr unsafeBuffer, int length)
        {
            byte[] safeBuffer = new byte[length];
            Marshal.Copy(unsafeBuffer, safeBuffer, 0, length);
            Console.WriteLine("Error: "+Encoding.UTF8.GetString(safeBuffer));
        }
        #endregion
