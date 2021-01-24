    void RefreshAlgorithms()
    {
        var appDomain = AppDomain.CreateDomain("TempDomain");
        appDomain.Load(YourAssembly);
        appDomain.DoCallback(Inspect);
        AppDomain.Unload(appDomain);
    }
    void Inspect()
    {
        // This runs in the new appdomain where you can inspect your classes
    }
