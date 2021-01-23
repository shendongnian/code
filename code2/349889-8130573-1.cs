    AppDomainSetup setup = new AppDomainSetup();
    setup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
    
    Evidence evidence = new Evidence(AppDomain.CurrentDomain.Evidence);
    evidence.AddAssembly(Assembly.GetExecutingAssembly().FullName);
    evidence.AddHost(new Zone(SecurityZone.MyComputer));
    AppDomain ad = AppDomain.CreateDomain(DomainName, evidence, setup);
    ScriptMain mainClass = (ScriptMain)ad.CreateInstanceAndUnwrap(typeof(ScriptMain).Assembly.FullName, typeof(ScriptMain).FullName);      
         
