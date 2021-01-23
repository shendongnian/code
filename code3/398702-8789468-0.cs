    int locale = CultureInfo.CurrentCulture.LCID;
    bool useEmulator = true;
    var datastoreManager = new DatastoreManager(locale);
    var phonePlatform = datastoreManager.GetPlatforms()
        .Single(p => p.Name == "Windows Phone 7");
    var phoneDevice = phonePlatform.GetDevices()
        .First(d => d.IsEmulator() == useEmulator);
    phoneDevice.Connect();
    var apps = phoneDevice.GetInstalledApplications();
    foreach(RemoteApplication app in apps)
    {
        Console.WriteLine(app.ProductID.ToString());
    }
    phoneDevice.Disconnect();
