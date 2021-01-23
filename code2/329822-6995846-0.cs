    using System.Management;
    uint32 cachsize;
    public void CPUSpeed()
    {
      using(ManagementObject Mo = new ManagementObject("Win32_Processor.DeviceID='CPU0'"))
      {
        cachsize = (uint)(Mo["L2CacheSize"]);
      }
    }
