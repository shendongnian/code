    using System.Management;
    uint currentsp , Maxsp;
    public void CPUSpeed()
    {
       using(ManagementObject Mo = new ManagementObject("Win32_Processor.DeviceID='CPU0'"))
       {
           currentsp = (uint)(Mo["CurrentClockSpeed"]);
           Maxsp = (uint)(Mo["MaxClockSpeed"]);
       }
    }
