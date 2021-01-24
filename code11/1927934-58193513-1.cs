    using Android.Net.Wifi;
    ...
    var wifiMgr = (WifiManager)GetSystemService(WifiService);
    var wifiList = wifiMgr.ScanResults;
    foreach (var item in wifiList)
    {
        var wifiLevel = WifiManager.CalculateSignalLevel(item.Level, 100);
        Console.WriteLine($"Wifi SSID: {item.Ssid} - Strengh: {wifiLevel}");
    }
