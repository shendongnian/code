    Evidence ev = new Evidence();
    ev.AddHostEvidence(new Zone(SecurityZone.Internet));
    PermissionSet internetPS = SecurityManager.GetStandardSandbox(ev);
    
    AppDomainSetup adSetup = new AppDomainSetup();
    adSetup.ApplicationBase = Path.GetFullPath(pathToUntrusted);
    
    AppDomain newDomain = AppDomain.CreateDomain("Sandbox Domain", null, adSetup, internetPS);
    
    newDomain.ExecuteAssemblyByName(untrustedAssembly);
