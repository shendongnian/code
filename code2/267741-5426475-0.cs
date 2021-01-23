    #region Usings
    using System.Text;
    using System.Runtime.InteropServices;
    #endregion
    /// <summary>
    /// Communicates with ini files
    /// </summary>
    public static class IniFile
    {
        #region Declarations
        #endregion
        #region Constructor/Deconstructor
        /// <summary>
        /// Initializes a new instance of the <see cref="IniFile"/> class.
        /// </summary>
        static IniFile()
        {
        }
        #endregion
        #region Properties
        #endregion
        #region Win32_API
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(
            string section,
            string key, string def,
            StringBuilder retVal,
            int size, string filePath);
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool WritePrivateProfileString(string lpAppName,
           string lpKeyName, string lpString, string lpFileName);
        #endregion
        /// <summary>
        /// Reads the ini value.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <param name="key">The key.</param>
        /// <param name="iniFilePath">The ini file path.</param>
        /// <returns>Value stored in key</returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static string ReadIniValue(string section, string key, string iniFilePath)
        {
            if(!File.Exists(iniFilePath))
            {
                throw new FileNotFoundException();
            }
            const int size = 255;
            var buffer = new StringBuilder(size);
            var len = GetPrivateProfileString(section, key, string.Empty, buffer, size, iniFilePath);
            if (len > 0)
            {
                return buffer.ToString();
            }
            return string.Empty;
        }
        
        /// <summary>
        /// Writes the ini value.
        /// </summary>
        /// <param name="section">The section.</param>
        /// <param name="keyname">The keyname.</param>
        /// <param name="valueToWrite">The value to write.</param>
        /// <param name="iniFilePath">The ini file path.</param>
        /// <returns>true if write was successful, false otherwise</returns>
        public static bool WriteIniValue(string section,string keyname,string valueToWrite,string iniFilePath)
        {
            return WritePrivateProfileString(section, keyname, valueToWrite, iniFilePath);
        }
    }
