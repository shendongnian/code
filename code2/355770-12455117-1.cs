    using Microsoft.Win32;
    using System.Management;
    
    private Boolean SetComputerName(String Name)
    {
      String RegLocComputerName = 
        @"SYSTEM\CurrentControlSet\Control\ComputerName\ComputerName";
      try
      {
         string compPath= 
           "Win32_ComputerSystem.Name='" + System.Environment.MachineName + "'";
         using (ManagementObject mo = new ManagementObject(new ManagementPath(compPath)))
         {
           ManagementBaseObject inputArgs = mo.GetMethodParameters("Rename");
           inputArgs["Name"] = Name;
           ManagementBaseObject output = mo.InvokeMethod("Rename", inputArgs, null);
           uint retValue = 
             (uint)Convert.ChangeType(
             output.Properties["ReturnValue"].Value, typeof(uint));
           if (retValue != 0)
           {
             throw new Exception("Computer could not be changed due to unknown reason.");
           }
         }
    
        //Check registry to validate the computername was set
        RegistryKey ComputerName = Registry.LocalMachine.OpenSubKey(RegLocComputerName);
        if (ComputerName == null)
        {
           throw new Exception(
             "Registry location '" + RegLocComputerName + "' is not readable.");
        }
        if (((String)ComputerName.GetValue("ComputerName")) != Name)
        {
          throw new Exception(
            "The computer name was set by WMI but was not updated in the registry location: '"
            + RegLocComputerName + "'");
        }
      }
      catch (Exception ex)
      {
        ShowError("Could not set computer name: " + ex.Message);
        return false;
      }
      return true;
    }
