    using System.Management;
    
    string objPath = string.Format("Win32_Service.Name='{0}'", serviceName);
    using (ManagementObject service = new ManagementObject(new ManagementPath(objPath)))
    {
       object[] wmiParams = new object[11];
       wmiParams[6] = username;
       wmiParams[7] = password;
       service.InvokeMethod("Change", wmiParams);
    }
