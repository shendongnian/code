    Using Microsoft.Phone.Net.NetworkInformation
    
    Using Microsoft.Phone.net.NetworkInfromation
    
    var Newlist = new NetworkInterfaceList();
    
    foreach (NetworkInterfaceInfo x in Newlist)
    
    {
    
    if(x.InterfaceState==ConnectState.Connected)
    
    {
    
    if(x.InterfaceSubtype.Equals(NetworkInterfaceSubType.WiFi))
    
    {
    
    Interface = x.InterfaceType.ToString();
    
    SubInterface = x.InterfaceSubtype.ToString();
    
    break;
    
    }
    
    else if(x.InterfaceSubtype.Equals(NetworkInterfaceSubType.Cellular_EVDO) || x.InterfaceSubtype.Equals(NetworkInterfaceSubType.Cellular_3G) || x.InterfaceSubtype.Equals(NetworkInterfaceSubType.Cellular_HSPA) || x.InterfaceSubtype.Equals(NetworkInterfaceSubType.Cellular_EVDV))
    
    {
    
    Interface = x.InterfaceType.ToString();
    
    SubInterface= “3G Network”;
    
    break;
    
    }
    
    else if(x.InterfaceSubtype.Equals(NetworkInterfaceSubType.Cellular_GPRS) || x.InterfaceSubtype.Equals(NetworkInterfaceSubType.Cellular_1XRTT) || x.InterfaceSubtype.Equals(NetworkInterfaceSubType.Cellular_EDGE))
    
    {
    
    Interface = x.InterfaceType.ToString();
    
    SubInterface= “2G Network”;
    
    break;
    
    }
    
    else
    
    {
    
    Interface = “Ethernet”;
    
    SubInterface= “Unknown” ;
    
    break;
    
    }
    
    }
    
    else
    
    {
    
    Interface=”not connected”;
    
    SubInterface=”unknown”;
    
    }
