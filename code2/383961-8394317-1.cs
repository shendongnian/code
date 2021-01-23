        public void UpdateRegistryAsUser(string sUser, string sPassword)
        {
            IntPtr tokenHandle = default(IntPtr);
            tokenHandle = SecurityGeneral.LogonAsUser(sUser, sPassword);
            if (!((tokenHandle == IntPtr.Zero)))
            {
                WindowsImpersonationContext oImpersonatedUser = null;
                try
                {
                    // Use the token handle returned by LogonUser.
                    WindowsIdentity oNewIdentity = new WindowsIdentity(tokenHandle);
                    
                    oImpersonatedUser = oNewIdentity.Impersonate();
                    // ToDo: add your registry updates here
                }
                finally
                {
                    // Stop impersonating the user.
                    if (oImpersonatedUser != null)
                    {
                        oImpersonatedUser.Undo();
                    }
                    SecurityGeneral.LogonAsUserEnd(tokenHandle);
                }
            }
        }
