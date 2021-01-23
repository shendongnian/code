    ConnectionOptions options = new ConnectionOptions();
    options.Username = userName;
    options.Password = password;
    ManagementScope scope = new ManagementScope(string.Format(@"\\{0}\root\cimv2", serverFullName), options);
    scope.Connect();
    ObjectQuery query = new ObjectQuery(string.Format(@"SELECT * FROM Win32_Service WHERE Name='{0}'",serviceToStop));
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
    ManagementObjectCollection queryCollection = searcher.Get();
    foreach (ManagementObject m in queryCollection)
    {
       m.InvokeMethod("StopService", null);
    }
