    AppDomain cad = AppDomain.CurrentDomain;
    AppDomainSetup cads = cad.SetupInformation;
    var setup = new AppDomainSetup
    {
        ApplicationName = cads.ApplicationName,
        ApplicationBase = cads.ApplicationBase,
        DynamicBase = cads.DynamicBase,
        CachePath = cads.CachePath,
        PrivateBinPath = cads.PrivateBinPath,
        ShadowCopyDirectories = cads.ShadowCopyDirectories,
        ShadowCopyFiles = cads.ShadowCopyFiles,
        ApplicationTrust = cads.ApplicationTrust,
        LoaderOptimization = LoaderOptimization.SingleDomain
    };
    setup.SetCompatibilitySwitches(new[] { "NetFx40_LegacySecurityPolicy" });
    AppDomain _casPolicyEnabledDomain = AppDomain.CreateDomain("Dummy", cad.Evidence,setup
    );
