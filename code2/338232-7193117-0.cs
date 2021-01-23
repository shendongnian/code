    foreach(var nic in NetworkInterface.GetAllNetworkInterfaces.Where(n => n.OperationalStatus == OperationStatus.UP)
    {
        if(nic.GetIsNetworkAvailable())
        {
           //nic is attached to some form of network
        }
    }
