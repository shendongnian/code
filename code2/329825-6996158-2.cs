    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management;
    
    namespace Scratch
    {
        public enum CacheLevel : ushort 
        {
            Level1 = 3,
            Level2 = 4,
            Level3 = 5,
        }
        
        public static class CPUInfo
        {
            public static List<uint> GetCacheSizes(CacheLevel level)
            {
                ManagementClass mc = new ManagementClass("Win32_CacheMemory");
                ManagementObjectCollection moc = mc.GetInstances();
                List<uint> cacheSizes = new List<uint>(moc.Count);
    
                cacheSizes.AddRange(moc
                  .Cast<ManagementObject>()
                  .Where(p => (ushort)(p.Properties["Level"].Value) == (ushort)level)
                  .Select(p => (uint)(p.Properties["MaxCacheSize"].Value)));
    
                return cacheSizes;
            }
        }
    }
