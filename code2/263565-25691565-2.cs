    var currentList = new NetworkInterfaceList().Where(i => i.InterfaceState == ConnectState.Connected).Select(i => i.InterfaceSubtype);
    if (currentList.Contains(NetworkInterfaceSubType.WiFi))
        Debug.WriteLine("WiFi");
    if (currentList.Intersect(new NetworkInterfaceSubType[]
    {
        NetworkInterfaceSubType.Cellular_EVDO,
        NetworkInterfaceSubType.Cellular_3G,
        NetworkInterfaceSubType.Cellular_HSPA,
        NetworkInterfaceSubType.Cellular_EVDV,
    }).Any())
        Debug.WriteLine("3G");
    if (currentList.Intersect(new NetworkInterfaceSubType[]
    {
        NetworkInterfaceSubType.Cellular_GPRS,
        NetworkInterfaceSubType.Cellular_1XRTT,
        NetworkInterfaceSubType.Cellular_EDGE,
    }).Any())
        Debug.WriteLine("2G");
