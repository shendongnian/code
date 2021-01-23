    using System.Management; //Add in a reference to this as well in the project settings
    public static string GetPhysicalDevicePath(char DriveLetter)
    {
        ManagementClass devs = new ManagementClass( @"Win32_Diskdrive");
        {
            ManagementObjectCollection moc = devs.GetInstances();
            foreach(ManagementObject mo in moc)
            {
                foreach (ManagementObject b in mo.GetRelated("Win32_DiskPartition"))
                {
                    foreach (ManagementBaseObject c in b.GetRelated("Win32_LogicalDisk"))
                    {
                        string DevName = string.Format("{0}", c["Name"]);
                        if (DevName[0] == DriveLetter)
                            return string.Format("{0}", mo["DeviceId"]); 
                    }
                }
            }
        }
        return "";
    }
