	public static string GetSerialNumber(string logicalDrive)
	{
		using (var partitionsQuery = new ManagementObjectSearcher(string.Format("ASSOCIATORS OF {{Win32_LogicalDisk.DeviceID='{0}'}} WHERE ResultClass = Win32_DiskPartition", logicalDrive)))            
		{
			foreach (var results in partitionsQuery.Get())
			{
				using (var diskDrives = new ManagementObjectSearcher(string.Format("ASSOCIATORS OF {{Win32_DiskPartition.DeviceID='{0}'}} WHERE ResultClass=Win32_DiskDrive", results["DeviceID"])))
				{
					foreach (var d in diskDrives.Get())
					{
						Console.WriteLine("Serial: " + d["SerialNumber"]);
						return d["SerialNumber"].ToString();
					}
				}
			}
		}
		return null;
	} 
