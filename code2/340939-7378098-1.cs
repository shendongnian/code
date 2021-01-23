    dynamic networkListManager = Activator.CreateInstance(
         Type.GetTypeFromCLSID(new Guid("{DCB00C01-570F-4A9B-8D69-199FDBA5723B}")));
    
    var connections = networkListManager.GetNetworkConnections();
    foreach (var connection in connections)
    {
        var network = connection.GetNetwork();
        Console.WriteLine("Network Name: " + network.GetName());
        Console.WriteLine("Network Category " + 
            network.GetCategory()+ " (0 public / 1 private / 2 Authenticated AD)" );
    }
