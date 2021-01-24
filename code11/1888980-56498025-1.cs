cs
void Main()
{
	string include = "SQL";
	string exclude = "EXPRESS,Writer";
	string[] includeArray = include.Split(',');
	string[] excludeArray = exclude.Split(',');
	ConnectionOptions options = new ConnectionOptions();
	//Scope that will connect to the default root for WMI
	ManagementScope theScope = new ManagementScope(@"root\cimv2");
	//Path created to the services with the default options
	ObjectGetOptions option = new ObjectGetOptions(null, TimeSpan.MaxValue, true);
	ManagementPath spoolerPath = new ManagementPath("Win32_Service");
	ManagementClass servicesManager = new ManagementClass(theScope, spoolerPath, option);
	using (ManagementObjectCollection services = servicesManager.GetInstances())
	{
		foreach (ManagementObject item in services)
		{
			var serviceName = item["Name"];
			if (includeArray.Any(a => serviceName.ToString().Contains(a)) && !excludeArray.Any(a => serviceName.ToString().Contains(a)))
			{
				if (item["Started"].Equals(true))
				{
					item.InvokeMethod("StopService", null);
				}
			}
		}
	}
}
