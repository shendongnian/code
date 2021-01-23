    foreach (var ni in NetworkInterface.GetAllNetworkInterfaces())
    {
        var wzc = ni as WirelessZeroConfigNetworkInterface;
        if(wzc != null)
        {
            Debug.Writeline("WZC Signal: " + wzc.SignalStrength.Decibels);
            continue;
        }
        var wni = ni as WirelessNetworkInterface 
        if(wni != null)
        {
            Debug.Writeline("Wireless Signal: " + wni.SignalStrength.Decibels);
            continue;
        }
        Debug.Writeline("No signal info available");
    }               
