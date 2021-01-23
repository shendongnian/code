    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Esatto.Win32.Processes
    {
        using System.ComponentModel;
        using System.Runtime.InteropServices;
        using System.Security.Principal;
        using static NativeMethods;
    
    #if ESATTO_WIN32
        public
    #else
        internal
    #endif
            static class ProcessInterop
        {
            public static void CreateProcessForSession(int sessionId, string exePath, string commandLine)
            {
                var privs = new[] { Privilege.TrustedComputingBase, Privilege.AssignPrimaryToken, Privilege.IncreaseQuota };
                Privilege.RunWithPrivileges(() => CreateProcessForSessionInternal(sessionId, exePath, commandLine), privs);
            }
    
            private static void CreateProcessForSessionInternal(int sessionId, string exePath, string commandLine)
            {
                SafeTokenHandle hDupToken;
                {
                    SafeTokenHandle hToken;
                    if (!WTSQueryUserToken(sessionId, out hToken))
                    {
                        throw new Win32Exception();
                    }
    
                    using (hToken)
                    {
                        if (!DuplicateTokenEx(hToken, TokenAccessLevels.AllAccess, IntPtr.Zero, SecurityImpersonationLevel.Impersonation, TokenType.Primary, out hDupToken))
                        {
                            throw new Win32Exception();
                        }
                    }
                }
    
                using (hDupToken)
                {
                    EnvironmentBlockSafeHandle env;
                    if (!CreateEnvironmentBlock(out env, hDupToken, false))
                    {
                        throw new Win32Exception();
                    }
    
                    using (env)
                    {
                        STARTUPINFO si = new STARTUPINFO();
                        si.cb = Marshal.SizeOf(si);
    
                        PROCESS_INFORMATION procInfo;
                        if (!CreateProcessAsUser(hDupToken, new StringBuilder(exePath), new StringBuilder(commandLine),
                            IntPtr.Zero, IntPtr.Zero, false, NORMAL_PRIORITY_CLASS | CREATE_UNICODE_ENVIRONMENT, env,
                            null, ref si, out procInfo))
                        {
                            throw new Win32Exception();
                        }
    
                        CloseHandle(procInfo.hProcess);
                        CloseHandle(procInfo.hThread);
                    }
                }
            }
    
            public static int GetSessionId(this WindowsIdentity ident)
            {
                if (ident == null)
                {
                    throw new ArgumentNullException();
                }
    
                int sessionId;
                uint unused;
                if (!GetTokenInformation(ident.Token, TokenInformationClass.TokenSessionId, out sessionId, 4, out unused))
                {
                    throw new Win32Exception();
                }
                // since we are not passing a SafeHandle, we need to keep our reference on the SafeHandle
                // contained in the WindowsIdentity
                GC.KeepAlive(ident);
    
                return sessionId;
            }
        }
    }
