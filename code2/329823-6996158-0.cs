    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management;
    
    namespace Scratch
    {
        public static class GetCPUInfo
        {
            public static List<uint> GetLevel1CacheSizes()
            {
                const int Level1 = 3;
    
                ManagementClass mc = new ManagementClass("Win32_CacheMemory");
                ManagementObjectCollection moc = mc.GetInstances();
                List<uint> level1CacheSizes = new List<uint>(moc.Count);
    
                level1CacheSizes.AddRange(moc
                    .Cast<ManagementObject>()
                    .Where(p => (ushort)(p.Properties["Level"].Value) == Level1)
                    .Select(p => (uint)(p.Properties["MaxCacheSize"].Value)));
    
                return level1CacheSizes;
            }
        }
    }
