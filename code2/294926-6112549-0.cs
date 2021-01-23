    using System.Management;
    .....
    ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
    disk.Get();
    MessageBox.Show(disk["FreeSpace"] + " bytes");  // Displays disk free space
    MessageBox.Show(disk["VolumeName"].ToString()); // Displays disk label
    MessageBox.Show(disk["FileSystem"].ToString()); // Displays File system type   
