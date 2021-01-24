    if (hostingEnvironment.IsDevelopment())
    {
        Assembly assembly = Assembly.Load(new 
                  AssemblyName(hostingEnvironment.ApplicationName));
        if (assembly != (Assembly) null)
              config.AddUserSecrets(assembly, true);
     }
