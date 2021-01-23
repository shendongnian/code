    using System.Management;
    private string GetProcessorID()
    {
    
      ManagementClass mgt = new ManagementClass("Win32_Processor");
      ManagementObjectCollection procs= mgt.GetInstances();
      
      return mgt[0].Properties["ProcessorId"].Value.ToString();
    }
