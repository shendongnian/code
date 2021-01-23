    AppDomain hostDomain = AppDomain.CurrentDomain;
    domain = AppDomain.CreateDomain("ClientKernel", null, setup);
    domain.UnhandledException += (s, e) => {
       hostDomain.DoCallBack(() => { SomeStaticClass.LoadAndLaunchAppDomain("someAssembly", "someClassName"); }
    }
