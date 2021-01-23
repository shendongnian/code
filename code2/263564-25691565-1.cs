    var currentList = new NetworkInterfaceList().Where(i => i.InterfaceState == ConnectState.Connected).Select(i => i.InterfaceSubtype);
    if (currentList.Contains(NetworkInterfaceSubtype.WiFi))
        Debug.WriteLine("WiFi");
    if (currentList.Intersect(new NetworkInterfaceSubType[]
    {
        NetworkInterfaceSubtype.Cellular_EVDO,
        NetworkInterfaceSubtype.Cellular_3G,
        NetworkInterfaceSubtype.Cellular_HSPA,
        NetworkInterfaceSubtype.Cellular_EVDV,
    }).Any())
        Debug.WriteLine("3G");
    if (currentList.Intersect(new NetworkInterfaceSubType[]
    {
        NetworkInterfaceSubtype.Cellular_GPRS,
        NetworkInterfaceSubtype.Cellular_1XRTT,
        NetworkInterfaceSubtype.Cellular_EDGE,
    }).Any())
        Debug.WriteLine("2G");
