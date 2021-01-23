            #region SecureString Manipulation
        /// <summary>
        /// Convert a Securestring to a regular string (not considered best practice, but make sure it's not in memory if you can help it)
        /// </summary>
        /// <param name="securePassword">Password stored in a secure string</param>
        /// <returns>regular string of securestring password</returns>
        public static string ConvertToUnsecureString(this System.Security.SecureString securePassword)
        {
            if (securePassword == null)
                throw new ArgumentNullException("securePassword");
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
        /// <summary>
        /// Pass a text password to this function to return a SecureString (doesn't store the password in memory)
        /// </summary>
        /// <param name="password">Text version of a password</param>
        /// <returns>SecureString of a password (not readable by memory)</returns>
        public static SecureString ConvertToSecureString(this string password)
        {
            if (password == null)
                throw new ArgumentNullException("password");
            var secure = new SecureString();
            foreach (var c in password.ToCharArray())
                secure.AppendChar(c);
            return secure;
        }
        #endregion
