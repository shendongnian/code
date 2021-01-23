    /// <summary>
        /// Does the actual impersonation.
        /// </summary>
        /// <param name="userName">The name of the user to act as.</param>
        /// <param name="domainName">The domain name of the user to act as.</param>
        /// <param name="password">The password of the user to act as.</param>
        private void ImpersonateValidUser(
            string userName, 
            string domain, 
            string password )
        {
            WindowsIdentity tempWindowsIdentity = null;
            IntPtr token = IntPtr.Zero;
            IntPtr tokenDuplicate = IntPtr.Zero;
            try
            {
                if ( RevertToSelf() )
                {
                    if ( LogonUser(
                        userName, 
                        domain, 
                        password, 
                        LOGON32_LOGON_INTERACTIVE,
                        LOGON32_PROVIDER_DEFAULT, 
                        ref token ) != 0 )
                    {
                        if ( DuplicateToken( token, 2, ref tokenDuplicate ) != 0 )
                        {
                            tempWindowsIdentity = new WindowsIdentity( tokenDuplicate );
                            impersonationContext = tempWindowsIdentity.Impersonate();
                        }
                        else
                        {
                            throw new Win32Exception( Marshal.GetLastWin32Error() );
                        }
                    }
                    else
                    {
                        throw new Win32Exception( Marshal.GetLastWin32Error() );
                    }
                }
                else
                {
                    throw new Win32Exception( Marshal.GetLastWin32Error() );
                }
            }
            finally
            {
                if ( token!= IntPtr.Zero )
                {
                    CloseHandle( token );
                }
                if ( tokenDuplicate!=IntPtr.Zero )
                {
                    CloseHandle( tokenDuplicate );
                }
            }
        }
        /// <summary>
        /// Reverts the impersonation.
        /// </summary>
        private void UndoImpersonation()
        {
            if ( impersonationContext!=null )
            {
                impersonationContext.Undo();
            }   
        }
        private WindowsImpersonationContext impersonationContext = null;
