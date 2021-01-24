        public static void ExecuteAsUserFromService(string appExeFullPath, uint activeSessionId, bool isVisible = false, string cmdLine = null, string workDir = null)
        {
            var tokenUser = GetUserImpersonatedToken(activeSessionId);
            try
            {
                if (!AdvApi32.SetTokenInformation(tokenUser, AdvApi32.TokenInformationClass.TokenSessionId, ref activeSessionId, sizeof(UInt32)))
                    Win32Helper.RaiseInvalidOperation("SetTokenInformation");
                ExecuteAsUser(tokenUser, appExeFullPath, isVisible, cmdLine, workDir);
            }
            finally
            {
                Kernel32.CloseHandle(tokenUser);
            }
        }
