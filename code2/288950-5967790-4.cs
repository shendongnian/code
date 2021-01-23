    using System;
    using System.Collections.Generic;
    using System.Text;
    
    using System.Management;
    
    namespace WMIQuery
    {
      class WmiQuery
      {
        static void Main(string[] args)
        {
          ManagementObjectSearcher domainInfos = new ManagementObjectSearcher("select * from WIN32_NTDomain");
    
          foreach (ManagementObject domainInfo in domainInfos.Get())
          {
            Console.WriteLine("Name : {0}", domainInfo.GetPropertyValue("Name"));
            Console.WriteLine("Computer/domain : {0}", domainInfo.GetPropertyValue("Caption"));
            Console.WriteLine("Domain name : {0}", domainInfo.GetPropertyValue("DomainName"));
            Console.WriteLine("Status : {0}", domainInfo.GetPropertyValue("Status"));
          }
          // Edition according to @ScottTx comment you can also use `Win32_ComputerSystem` WMI class
          ManagementObjectSearcher ComputerInfos = new ManagementObjectSearcher("select * from Win32_ComputerSystem");
          foreach (ManagementObject ComputerInfo in ComputerInfos.Get())
          {
            if ((bool)ComputerInfo.GetPropertyValue("PartOfDomain"))
              Console.WriteLine("This computer is part of domain");
            else
              Console.WriteLine("This computer is not part of domain");
          }
        }
      }
    }
