    namespace Helpers
    {
        using System.Management;
    
        public static class HardwareHelpers
        {
            private static uint? maxCpuSpeed = null;
            public static uint MaxCpuSpeed
            {
                get
                {
                    return maxCpuSpeed.HasValue ? maxCpuSpeed.Value : (maxCpuSpeed = GetMaxCpuSpeed()).Value;
                }
            }
    
            private static uint GetMaxCpuSpeed()
            {
                using (var managementObject = new ManagementObject("Win32_Processor.DeviceID='CPU0'"))
                {
                    var sp = (uint)(managementObject["MaxClockSpeed"]);
    
                    return sp;
                }
            }
        }
    }
