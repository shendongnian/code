    ForEach nic in NetworkInterface.GetAllNetworkInterfaces.Where(Function(n) n.OperationalStatus = OperationStatus.UP)
        If nic.GetIsNetworkAvailable() Then
           //nic is attached to some form of network
        End If
    Next
