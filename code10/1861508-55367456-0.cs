	static void Main()
	{
		// Create a scope (connection to WMI)
		var scope = new ManagementScope(@"\\localhost\root\cimv2");
		// Create query
		var query = new ObjectQuery(@"SELECT Name,Caption FROM Win32_Service WHERE PathName like '%Binn\\sqlserv%'");
		// Create a search to run the query against the scope
		using (var search = new ManagementObjectSearcher(scope, query))
		{
			// Iterate through the query results
			foreach (var item in search.Get())
			{
				// get values, all strings in this case
				string name = (string)item["Name"];
				string caption = (string)item["Caption"];
				Console.WriteLine("{0}\t{1}", name, caption);
			}
		}
	}
