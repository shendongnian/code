            private void CreateUserProcess()
        {
            bool ret;
            SECURITY_ATTRIBUTES sa = new SECURITY_ATTRIBUTES();
            uint dwSessionID = WTSGetActiveConsoleSessionId();
            this.EventLog.WriteEntry("WTSGetActiveConsoleSessionId: " + dwSessionID, EventLogEntryType.FailureAudit);
            IntPtr Token = new IntPtr();
            ret = WTSQueryUserToken((UInt32)dwSessionID, out Token);
            if (ret == false)
            {
                this.EventLog.WriteEntry("WTSQueryUserToken failed with " + Marshal.GetLastWin32Error(), EventLogEntryType.FailureAudit);
            }
            const uint MAXIMUM_ALLOWED  = 0x02000000;
            IntPtr DupedToken = IntPtr.Zero;
            ret = DuplicateTokenEx(Token,
                MAXIMUM_ALLOWED,
                ref sa,
                SECURITY_IMPERSONATION_LEVEL.SecurityIdentification,
                TOKEN_TYPE.TokenPrimary,
                out DupedToken);
            if (ret == false)
            {
                this.EventLog.WriteEntry("DuplicateTokenEx failed with " + Marshal.GetLastWin32Error(), EventLogEntryType.FailureAudit);
            }
            else
            {
                this.EventLog.WriteEntry("DuplicateTokenEx SUCCESS", EventLogEntryType.SuccessAudit); 
            }
            STARTUPINFO si = new STARTUPINFO();
            si.cb = Marshal.SizeOf(si);
            //si.lpDesktop = "";
            string commandLinePath;
            
            // commandLinePath example: "c:\myapp.exe c:\myconfig.xml" . cmdLineArgs can be ommited
            commandLinePath = AppPath + " " + CmdLineArgs;
            PROCESS_INFORMATION pi = new PROCESS_INFORMATION();
            //CreateProcessAsUser(hDuplicatedToken, NULL, lpszClientPath, NULL, NULL, FALSE,
            //                    0,
            //                    NULL, NULL, &si, &pi)
            ret = CreateProcessAsUser(DupedToken, null, commandLinePath, ref sa, ref sa, false, 0, (IntPtr)0, null, ref si, out pi);
            if (ret == false)
            {
                this.EventLog.WriteEntry("CreateProcessAsUser failed with " + Marshal.GetLastWin32Error(), EventLogEntryType.FailureAudit);
            }
            else
            {
                this.EventLog.WriteEntry("CreateProcessAsUser SUCCESS.  The child PID is" + pi.dwProcessId, EventLogEntryType.SuccessAudit);
                CloseHandle(pi.hProcess);
                CloseHandle(pi.hThread);
            }
            ret = CloseHandle(DupedToken);
            if (ret == false)
            {
                this.EventLog.WriteEntry("CloseHandle LastError: " + Marshal.GetLastWin32Error(), EventLogEntryType.Error);
            }
            else
            {
            this.EventLog.WriteEntry("CloseHandle SUCCESS", EventLogEntryType.Information);
            }
        }
