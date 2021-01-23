    public class DnsUtils  
    {        
        [DllImport("dnsapi.dll", EntryPoint="DnsFlushResolverCache")]
        static extern UInt32 DnsFlushResolverCache();
    
        [DllImport("dnsapi.dll", EntryPoint = "DnsFlushResolverCacheEntry_A")]
        public static extern int DnsFlushResolverCacheEntry(string hostName);
    
        public static void FlushCache()
        {
            DnsFlushResolverCache();
        }
    
        public static void FlushCache(string hostName)
        {
            DnsFlushResolverCacheEntry(hostName);
        }
    }
