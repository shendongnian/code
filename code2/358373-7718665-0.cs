    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        private struct SHQUERYRBINFO
        {
            /// DWORD->unsigned int
            public uint cbSize;
            /// __int64
            public long i64Size;
            /// __int64
            public long i64NumItems;
        }
        /// Return Type: HRESULT->LONG->int
        ///pszRootPath: LPCTSTR->LPCWSTR->WCHAR*
        ///pSHQueryRBInfo: LPSHQUERYRBINFO->_SHQUERYRBINFO*
        [System.Runtime.InteropServices.DllImportAttribute("shell32.dll", EntryPoint = "SHQueryRecycleBinW")]
        private static extern int SHQueryRecycleBinW([System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPTStr)] string pszRootPath, ref SHQUERYRBINFO pSHQueryRBInfo);
        public bool DriveHasRecycleBin(string Drive)
        {
            SHQUERYRBINFO Info = new SHQUERYRBINFO();
            Info.cbSize = 20; //sizeof(SHQUERYRBINFO)
            return SHQueryRecycleBinW(Drive, ref Info) == 0;
        }
