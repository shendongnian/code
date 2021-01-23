    var location = "";
    foreach (var p in InstalledProduct.Enumerate())
    {
        try
        {
            if (p.InstalledProductName.Contains("AppName"))                     
            {
                location = p.InstallLocation;
                break;
            }
        } 
        catch { }
    }
