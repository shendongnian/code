    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WINHTTP_PROXY_INFO
    {
        public AccessType AccessType;
        public string Proxy;
        public string Bypass;
    }
    
    public enum AccessType
    {
        DefaultProxy = 0,
        NamedProxy = 3,
        NoProxy = 1
    }
    
    class Program
    {
        [DllImport("winhttp.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool WinHttpSetDefaultProxyConfiguration(ref WINHTTP_PROXY_INFO config);
    
        static void Main()
        {
            var config = new WINHTTP_PROXY_INFO();
            config.AccessType = AccessType.NamedProxy;
            config.Proxy = "http://proxy.yourcompany.com:8080";
            config.Bypass = "intranet.com";
    
            var result = WinHttpSetDefaultProxyConfiguration(ref config);
            if (!result)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            else
            {
                Console.WriteLine("Successfully modified proxy settings");
            }
        }
    }
