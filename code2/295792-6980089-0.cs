    kernel.Scan(a =>
      {
        a.FromAssembliesInPath(directoryInfo.FullName);
        a.AutoLoadModules();
        a.BindWithDefaultConventions();
        a.InRequestScope();  // <-- ***
      });
