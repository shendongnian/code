    var ctl = ServiceController
        .GetServices()
        .FirstOrDefault(s => s.ServiceName == "MyService");
    if (ctl != null) {
        // get version substring, you might have your own style.
        string substr = s.DisplayName.SubString("MyService".Length);
        Version installedVersion = new Version(substr);
        // do stuff, e.g. check if installed version is newer than current assembly.
    }
