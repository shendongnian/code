    static void Main(string[] args)
    {
        //  example call
        string device = FindPath("VID_0781&PID_5583");
        GetDriveLetter(device); 
    }
    static public string FindPath(string pattern)
    {
        var USBobjects = new List<string>();
        string Entity = "*none*";
        foreach (ManagementObject entity in new ManagementObjectSearcher(
                 $"select * from Win32_USBHub Where DeviceID Like '%{pattern}%'").Get())
        {
            Entity = entity["DeviceID"].ToString();
            foreach (ManagementObject controller in entity.GetRelated("Win32_USBController"))
            {
                foreach (ManagementObject obj in new ManagementObjectSearcher(
                         "ASSOCIATORS OF {Win32_USBController.DeviceID='" 
                         + controller["PNPDeviceID"].ToString() + "'}").Get())
                {
                    if (obj.ToString().Contains("DeviceID"))
                        USBobjects.Add(obj["DeviceID"].ToString());
                }
            }
        }
        int VidPidposition = USBobjects.IndexOf(Entity);
        for (int i = VidPidposition; i <= USBobjects.Count; i++)
        {
            if (USBobjects[i].Contains("USBSTOR"))
            {
                return USBobjects[i];
            }
        }
        return "*none*";
    }
    public static void GetDriveLetter(string device)
    {
        int driveCount = 0;
        foreach (ManagementObject drive in new ManagementObjectSearcher("select * from Win32_DiskDrive").Get())
        {
            if (drive["PNPDeviceID"].ToString() == device)
            {
                foreach (ManagementObject o in drive.GetRelated("Win32_DiskPartition"))
                {
                    foreach (ManagementObject i in o.GetRelated("Win32_LogicalDisk"))
                    {
                        Console.WriteLine("Disk: " + i["Name"].ToString());
                        driveCount++;
                    }
                }
            }
        }
        if (driveCount == 0)
        {
            Console.WriteLine("No drive identified!");
        }
    }
