    var connectionOptions = new ConnectionOptions();
    var scope = new System.Management.ManagementScope("\\\\localhost", connectionOptions);
    var query = new System.Management.ObjectQuery("select * from Win32_ComputerSystem");
    var searcher = new ManagementObjectSearcher(scope, query);
    foreach (var row in searcher.Get()) 
    {
    	Console.WriteLine(row["UserName"].ToString().ToLower());
    }
