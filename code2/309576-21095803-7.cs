        [DllImport("odbccp32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool SQLGetInstalledDriversW(char[] lpszBuf, ushort cbufMax, out ushort pcbBufOut);
        /// <summary>
        /// Gets the ODBC driver names from the SQLGetInstalledDrivers function.
        /// </summary>
        /// <returns>a string array containing the ODBC driver names, if the call to SQLGetInstalledDrivers was successfull; null, otherwise.</returns>
        public static string[] GetOdbcDriverNames()
        {   
            string[] odbcDriverNames = null;
            char[] driverNamesBuffer = new char[ushort.MaxValue];
            ushort size;
            bool succeeded = SQLGetInstalledDriversW(driverNamesBuffer, ushort.MaxValue, out size);
            if (succeeded == true)
            {
                char[] driverNames = new char[size - 1];
                Array.Copy(driverNamesBuffer, driverNames, size - 1);
                odbcDriverNames = (new string(driverNames)).Split('\0');
            }
            return odbcDriverNames;
        }
