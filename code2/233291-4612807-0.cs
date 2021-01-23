            AppDomainSetup lDomainSetup = new AppDomainSetup();
            lDomainSetup.ApplicationName = "OtherAppDomain";
            lDomainSetup.ApplicationBase = AppDomain.CurrentDomain.BaseDirectory;
            lDomainSetup.PrivateBinPath = "bin";
            lDomainSetup.CachePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cache\\");
            lDomainSetup.ShadowCopyFiles = "true";
            lDomainSetup.ShadowCopyDirectories = @"C:\Users\gagan.dhamija\Desktop\My project\MainClass\MainClass\bin\Debug\MainClass.dll";
            lAppDomain = appDomainManager.CreateDomain("OtherDomain", null, lDomainSetup);
           lAppDomain.Load("MainClass");
            lAppDomain.InitializeLifetimeService();
            Assembly[] CollectionAssembly = lAppDomain.GetAssemblies();
            foreach (Assembly assembly in CollectionAssembly)
            {
                if (assembly.FullName == "MainClass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
                    Exportedvalues = GetAllExportedTypes(assembly);
            }
            MessageBox.Show("Loaded Assembly succesfully");
