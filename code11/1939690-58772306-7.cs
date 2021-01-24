        private static IntPtr GetUserImpersonatedToken(uint activeSessionId)
        {
            if (!WTSApi32.WTSQueryUserToken(activeSessionId, out var handleImpersonationToken))
                Win32Helper.RaiseInvalidOperation("WTSQueryUserToken");
            try
            {
                return DuplicateToken(handleImpersonationToken, AdvApi32.TokenType.TokenPrimary);
            }
            finally
            {
                Kernel32.CloseHandle(handleImpersonationToken);
            }
        }
