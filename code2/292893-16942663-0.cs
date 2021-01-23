    using System;
    using System.Runtime.InteropServices;
    
    namespace GetCurrentSessionId
    {
        class Program
        {
    
            enum TokenInformationClass
            {
                TokenUser = 1,
                TokenGroups,
                TokenPrivileges,
                TokenOwner,
                TokenPrimaryGroup,
                TokenDefaultDacl,
                TokenSource,
                TokenType,
                TokenImpersonationLevel,
                TokenStatistics,
                TokenRestrictedSids,
                TokenSessionId,
                TokenGroupsAndPrivileges,
                TokenSessionReference,
                TokenSandBoxInert,
                TokenAuditPolicy,
                TokenOrigin
            }
    
            enum TokenType
            {
                TokenPrimary = 1, 
                TokenImpersonation
            }
    
            enum SecurityImpersonationLevel 
            { 
                SecurityAnonymous,
                SecurityIdentification,
                SecurityImpersonation,
                SecurityDelegation
            }
    
            [StructLayout(LayoutKind.Sequential)]
            struct TokenStatistics
            {
                public Int64 TokenId;
                public Int64 AuthenticationId;
                public Int64 ExpirationTime;
                public TokenType TokenType;
                public SecurityImpersonationLevel ImpersonationLevel;
                public Int32 DynamicCharged;
                public Int32 DynamicAvailable;
                public Int32 GroupCount;
                public Int32 PrivilegeCount;
                public Int64 ModifiedId;
            }
    
            struct TokenOrigin
            {
                public Int64 OriginatingLogonSession;
            }
    
            [DllImport("advapi32.dll", EntryPoint = "GetTokenInformation", SetLastError = true)]
            static extern bool GetTokenInformation(
                IntPtr tokenHandle,
                TokenInformationClass tokenInformationClass,
                IntPtr tokenInformation,
                int tokenInformationLength,
                out int ReturnLength);
    
            public const int ERROR_INSUFFICIENT_BUFFER = 0x7a;
    
            static void Main(string[] args)
            {
                try
                {
                    Console.WriteLine("Session Id: {0}", System.Diagnostics.Process.GetCurrentProcess().SessionId);
    
                    IntPtr tokenInfo;
                    bool result;
                    int infoSize;
    
                    IntPtr hToken = System.Security.Principal.WindowsIdentity.GetCurrent().Token;
    
                    result = GetTokenInformation(hToken, TokenInformationClass.TokenStatistics, IntPtr.Zero, 0, out infoSize);
                    if (!result && Marshal.GetLastWin32Error() == ERROR_INSUFFICIENT_BUFFER)
                    {
                        tokenInfo = Marshal.AllocHGlobal(infoSize);
                        result = GetTokenInformation(hToken, TokenInformationClass.TokenStatistics, tokenInfo, infoSize, out infoSize);
                        if (result)
                        {
                            TokenStatistics tokenStats = (TokenStatistics)Marshal.PtrToStructure(tokenInfo, typeof(TokenStatistics));
                            Console.WriteLine("LogonId: 0x{0:X16}", tokenStats.AuthenticationId);
                        }
                        else
                        {
                            Console.Error.WriteLine("LogonId: FAILED with 0x{0:X08}", Marshal.GetLastWin32Error());
                        }
                        Marshal.FreeHGlobal(tokenInfo);
                    }
                    else
                    {
                        Console.Error.WriteLine("LogonId: FAILED with 0x{0:X08}", Marshal.GetLastWin32Error());
                    }
    
    
                    tokenInfo = Marshal.AllocHGlobal(sizeof (Int32));
                    result = GetTokenInformation(hToken, TokenInformationClass.TokenSessionId, tokenInfo, sizeof (Int32), out infoSize);
                    if (result)
                    {
                        int tokenSessionId = Marshal.ReadInt32(tokenInfo);
                        Console.WriteLine("TokenSessionId: {0}", tokenSessionId);
                    }
                    else
                    {
                        Console.Error.WriteLine("TokenSessionId: FAILED with 0x{0:X08}", Marshal.GetLastWin32Error());
                    }
    
                    Marshal.FreeHGlobal(tokenInfo);
    
    
                    result = GetTokenInformation(hToken, TokenInformationClass.TokenOrigin, IntPtr.Zero, 0, out infoSize);
                    if (!result && Marshal.GetLastWin32Error() == ERROR_INSUFFICIENT_BUFFER)
                    {
                        tokenInfo = Marshal.AllocHGlobal(infoSize);
                        result = GetTokenInformation(hToken, TokenInformationClass.TokenOrigin, tokenInfo, infoSize, out infoSize);
                        if (result)
                        {
                            TokenOrigin tokenOrigin = (TokenOrigin) Marshal.PtrToStructure(tokenInfo, typeof (TokenOrigin));
                            Console.WriteLine("OriginatingSessionId: 0x{0:X16}", tokenOrigin.OriginatingLogonSession);
                        }
                        else
                        {
                            Console.WriteLine("OriginatingSessionId: FAILED with 0x{0:X08}", Marshal.GetLastWin32Error());
                        }
                        Marshal.FreeHGlobal(tokenInfo);
                    }
                    else
                    {
                        Console.WriteLine("OriginatingSessionId: FAILED with 0x{0:X08}", Marshal.GetLastWin32Error());
                    }
    
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
    
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Unexpected error: {0}", ex);
                    Console.ReadKey();
                }
            }
        }
    }
