        [DllImport("msi.dll", CharSet = CharSet.Unicode)]
        internal static extern Int32 MsiGetPatchInfoEx(string szPatchCode, string szProductCode, string szUserSid, int dwContext, string szProperty, [Out] StringBuilder lpValue, ref Int32 pcchValue);
        // See http://msdn.microsoft.com/en-us/library/windows/desktop/aa370128%28v=vs.85%29.aspx 
        // for valid values for the property paramater
        private static string getPatchInfoProperty(string patchCode, string productCode, string property)
        {
            StringBuilder output = new StringBuilder(512);
            int len = 512;
            MsiGetPatchInfoEx(patchCode, productCode, null, 4, property, output, ref len);
            return output.ToString();
        }
        public static string GetPatchDisplayName(string patchCode, string productCode)
        {
            return getPatchInfoProperty(patchCode, productCode, "DisplayName");
        }
