    ConnectionOptions _connectionOptions = new ConnectionOptions();
    //Not required while checking it in local machine.
    //For remote machines you need to provide the credentials
    //options.Username = "";
    //options.Password = "";
    _connectionOptions.EnablePrivileges = true;
    _connectionOptions.Impersonation = ImpersonationLevel.Impersonate;
    //Connecting to SecurityCenter2 node for querying security details
    ManagementScope _managementScope = new ManagementScope(string.Format("\\\\{0}\\root\\SecurityCenter2", ipAddress), _connectionOptions);
    _managementScope.Connect();
    //Querying
    ObjectQuery _objectQuery = new ObjectQuery("SELECT * FROM AntivirusProduct");
    ManagementObjectSearcher _managementObjectSearcher =
        new ManagementObjectSearcher(_managementScope, _objectQuery);
    ManagementObjectCollection _managementObjectCollection = _managementObjectSearcher.Get();
    if (_managementObjectCollection.Count > 0)
    {
        foreach (ManagementObject item in _managementObjectCollection)
        {
            Console.WriteLine(item["displayName"]);
            //For Kaspersky AntiVirus, I am getting a null reference here.
            //Console.WriteLine(item["productUptoDate"]);
     
            //If the value of ProductState is 266240 or 262144, its an updated one.
            Console.WriteLine(item["productState"]);
        }
    }
