        [DllImport("kernel32.dll")]
        public static extern uint GetPrivateProfileSection(string lpAppName, IntPtr lpReturnedString, uint nSize, string lpFileName);
        // ReSharper disable once ReturnTypeCanBeEnumerable.Global
        public static string[] GetIniSectionRaw(string section, string file) {
            string[] iniLines;
            GetPrivateProfileSection(section, file, out iniLines);
            return iniLines;
        }
        /// <summary> Return an entire INI section as a list of lines.  Blank lines are ignored and all spaces around the = are also removed. </summary>
        /// <param name="section">[Section]</param>
        /// <param name="file">INI File</param>
        /// <returns> List of lines </returns>
        public static IEnumerable<KeyValuePair<string, string>> GetIniSection(string section, string file) {
            var result = new List<KeyValuePair<string, string>>();
            string[] iniLines;
            if (GetPrivateProfileSection(section, file, out iniLines)) {
                foreach (var line in iniLines) {
                    var m = Regex.Match(line, @"^([^=]+)\s*=\s*(.*)");
                    result.Add(m.Success
                                   ? new KeyValuePair<string, string>(m.Groups[1].Value, m.Groups[2].Value)
                                   : new KeyValuePair<string, string>(line, ""));
                }
            }
            return result;
        }
