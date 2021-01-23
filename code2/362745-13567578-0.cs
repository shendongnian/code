    class LDAPConnection : IDisposable
    {
        public static bool IsValidCredentials(string domain, string localAddress, 
                           string usernameDomain, string username, SecureString password)
        {
            try
            {
                using (LDAPConnection ldapConnection = 
                           new LDAPConnection(domain, LDAP_PORT, localAddress))
                {
                    ldapConnection.Bind(usernameDomain, username, password);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        protected IntPtr _ld;
        protected List<IntPtr> _stringPointers;
        public LDAPConnection(string hostname, uint port, params string[] localAddresses)
        {
            _stringPointers = new List<IntPtr>();
            _ld = LdapInit(hostname, port);
            LdapSetOption(_ld, LDAP_OPT_VERSION, LDAP_VERSION3);
            if (localAddresses != null && localAddresses.Length > 0)
            {
                string addr = string.Join(" ", localAddresses);
                IntPtr pStr = LdapSetOption(_ld, LDAP_OPT_SOCKET_BIND_ADDRESSES, addr);
                _stringPointers.Add(pStr);
            }
        }
        public void Bind(string domain, string username, SecureString password)
        {
            LdapBind(_ld, domain, username, password);
        }
        public void Dispose()
        {
            if (_ld != NULL) ldap_unbind_s(_ld);
            foreach (IntPtr pString in _stringPointers)
            {
                Marshal.FreeHGlobal(pString);
            }
        }
        [DllImport("wldap32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint LdapGetLastError();
        [DllImport("wldap32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        protected static extern IntPtr ldap_init(string HostName, uint PortNumber);
        //caller must call ldap_unbind or ldap_unbind_s on the return value
        public static IntPtr LdapInit(string hostname, uint port)
        {
            IntPtr ld = ldap_init(hostname, port);
            if (ld == NULL)
            {
                throw new Exception("LDAP Error: " + LdapGetLastError());
            }
            return ld;
        }
        [DllImport("wldap32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ldap_unbind_s(IntPtr ld);
        [DllImport("wldap32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ldap_set_option(IntPtr ld, uint option, ref IntPtr invalue);
        [DllImport("wldap32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ldap_set_option(IntPtr ld, uint option, ref uint invalue);
        //caller must free IntPtr after calling ldap_unbind_s
        public static IntPtr LdapSetOption(IntPtr ld, uint option, string invalue)
        {
            IntPtr pString = Marshal.StringToHGlobalUni(invalue);
            bool exception = true;
            try
            {
                uint errorCode = ldap_set_option(ld, option, ref pString);
                if (errorCode != LDAP_SUCCESS)
                {
                    throw new Exception("LDAP Error: " + errorCode);
                }
                exception = false;
                return pString;
            }
            finally
            {
                if (exception && pString != NULL)
                {
                    Marshal.FreeHGlobal(pString);
                }
            }
        }
        public static void LdapSetOption(IntPtr ld, uint option, uint invalue)
        {
            uint errorCode = ldap_set_option(ld, option, ref invalue);
            if (errorCode != LDAP_SUCCESS)
            {
                throw new Exception("LDAP Error: " + errorCode);
            }
        }
        [DllImport("wldap32.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        protected static extern uint ldap_bind_s(IntPtr ld, IntPtr dn, IntPtr cred, uint method);
        public static void LdapBind(IntPtr ld, string domain, 
                                    string username, SecureString password)
        {
            IntPtr cred = SEC_WINNT_AUTH_IDENTITY.GetUnicode(username, password, domain);
            try
            {
                uint errorCode = ldap_bind_s(ld, NULL, cred, LDAP_AUTH_NEGOTIATE);
                if (errorCode != LDAP_SUCCESS)
                {
                    throw new Exception("LDAP Error: " + errorCode);
                }
            }
            finally
            {
                if (cred != NULL) SEC_WINNT_AUTH_IDENTITY.Free(cred);
            }
        }
        public const uint LDAP_PORT = 389;
        public const uint LDAP_VERSION3 = 3;
        public const uint LDAP_SUCCESS = 0;
        public const uint LDAP_OPT_VERSION = 0x11;
        public const uint LDAP_OPT_SOCKET_BIND_ADDRESSES = 0x44;
        public const uint LDAP_AUTH_NEGOTIATE = 0x486;
        public static readonly IntPtr NULL = IntPtr.Zero;
        public const uint SEC_WINNT_AUTH_IDENTITY_ANSI = 1;
        public const uint SEC_WINNT_AUTH_IDENTITY_UNICODE = 2;
        [StructLayout(LayoutKind.Sequential)]
        public struct SEC_WINNT_AUTH_IDENTITY
        {
            public IntPtr User;
            public int UserLength;
            public IntPtr Domain;
            public int DomainLength;
            public IntPtr Password;
            public int PasswordLength;
            public uint Flags;
            public static IntPtr GetUnicode(string username, 
                                            SecureString password, string domain)
            {
                SEC_WINNT_AUTH_IDENTITY swai = new SEC_WINNT_AUTH_IDENTITY();
                bool exception = true;
                try
                {
                    swai.User = Marshal.StringToHGlobalUni(username);
                    swai.UserLength = username.Length;
                    swai.Domain = Marshal.StringToHGlobalUni(domain);
                    swai.DomainLength = domain.Length;
                    swai.Password = Marshal.SecureStringToGlobalAllocUnicode(password);
                    swai.PasswordLength = password.Length;
                    swai.Flags = SEC_WINNT_AUTH_IDENTITY_UNICODE;
                    IntPtr pSwai = Marshal.AllocHGlobal(Marshal.SizeOf(swai));
                    try
                    {
                        Marshal.StructureToPtr(swai, pSwai, false);
                        exception = false;
                        return pSwai;
                    }
                    finally
                    {
                        if (exception && pSwai != NULL)
                        {
                            Marshal.FreeHGlobal(pSwai);
                        }
                    }
                }
                finally
                {
                    if (exception)
                    {
                        if (swai.User != NULL) Marshal.FreeHGlobal(swai.User);
                        if (swai.Domain != NULL) Marshal.FreeHGlobal(swai.Domain);
                        if (swai.Password != NULL)
                        {
                            Marshal.ZeroFreeGlobalAllocUnicode(swai.Password);
                        }
                    }
                }
            }
            public static void Free(IntPtr pSwai)
            {
                SEC_WINNT_AUTH_IDENTITY swai = 
                    (SEC_WINNT_AUTH_IDENTITY)Marshal.PtrToStructure(
                        pSwai, typeof(SEC_WINNT_AUTH_IDENTITY));
                if (swai.Flags == SEC_WINNT_AUTH_IDENTITY_ANSI)
                {
                    Marshal.ZeroFreeGlobalAllocAnsi(swai.Password);
                }
                else
                {
                    Marshal.ZeroFreeGlobalAllocUnicode(swai.Password);
                }
                Marshal.FreeHGlobal(swai.Domain);
                Marshal.FreeHGlobal(swai.User);
                Marshal.FreeHGlobal(pSwai);
            }
        }
