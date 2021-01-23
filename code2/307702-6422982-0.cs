        /// <summary>
        /// Class that deals with another username credentials
        /// </summary>
        class Credentials
        {
            /// <summary>
            /// Constructor of SecureString password, to be used by RunAs
            /// </summary>
            /// <param name="text">Plain password</param>
            /// <returns>SecureString password</returns>
            private static SecureString MakeSecureString(string text)
            {
                SecureString secure = new SecureString();
                foreach (char c in text)
                {
                    secure.AppendChar(c);
                }
    
                return secure;
            }
    
            /// <summary>
            /// Run an application under another user credentials.
            /// Working directory set to C:\Windows\System32
            /// </summary>
            /// <param name="path">Full path to the executable file</param>
            /// <param name="username">Username of desired credentials</param>
            /// <param name="password">Password of desired credentials</param>
            public static void RunAs(string path, string username, string password)
            {
                try
                {
                    ProcessStartInfo myProcess = new ProcessStartInfo(path);
                    myProcess.UserName = username;
                    myProcess.Password = MakeSecureString(password);
                    myProcess.WorkingDirectory = @"C:\Windows\System32";
                    myProcess.UseShellExecute = false;
                    Process.Start(myProcess);
                }
                catch (Win32Exception w32E)
                {
                    // The process didn't start.
                    Console.WriteLine(w32E);
                }
            }
    
        }
