    /// <summary>
    /// Exécute une fonction en empruntant les credentials
    /// </summary>
    private T ApplyCredentials<T>(Func<T> func)
    {
        IntPtr token;
        if (!LogonUser(
            _credentials.UserName,
            _credentials.Domain,
            _credentials.Password,
            LOGON32_LOGON_INTERACTIVE,
            LOGON32_PROVIDER_DEFAULT,
            out token))
        {
            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
        }
        try
        {
            // On doit être impersonifié seulement le temps d'ouvrir le handle.
            using (var identity = new WindowsIdentity(token))
            using (var context = identity.Impersonate())
            {
                return func();
            }
        }
        finally
        {
            CloseHandle(token);
        }
    }
    // ...
    if (_credentials != null)
    {
        return this.ApplyCredentials(() => File.Open(path, mode, access, share));
    }
    return File.Open(path, mode, access, share);
