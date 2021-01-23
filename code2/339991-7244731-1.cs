    using System.Management;
    ...
    public string ReadHddSerial()
    {
    const string drive = "C";
    ManagementObject disk = new ManagementObject("Win32_LogicalDisk.DeviceID=\"" + drive + ":\"");
     if (disk != null)
     {
         disk.Get();
         return disk["VolumeSerialNumber"].ToString();
     }
     return "other value (random ?)";
    }
