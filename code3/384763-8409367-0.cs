            System.AppDomainSetup oSetup = new System.AppDomainSetup();
            string sApplicationFile = null;
            // Use this to ensure that if the application is running when the user performs the update, that we don't run into file locking issues.
            oSetup.ShadowCopyFiles = "true";
            oSetup.ApplicationName = sAppName;
            // Generate the name of the DLL we are going to launch
            sApplicationFile = System.IO.Path.Combine(sApplicationDirectory, sAppName + ".exe");
            oSetup.ApplicationBase = sApplicationDirectory;
            oSetup.ConfigurationFile = sApplicationFile + ".config";
            oSetup.LoaderOptimization = LoaderOptimization.MultiDomain;
            // Launch the application
            System.AppDomain oAppDomain = AppDomain.CreateDomain(sAppName, AppDomain.CurrentDomain.Evidence, oSetup);
            oAppDomain.SetData("App", sAppName);
            oAppDomain.SetData("User", sUserName);
            oAppDomain.SetData("Pwd", sUserPassword);
            oAppDomain.ExecuteAssembly(sApplicationFile);
            // When the launched application closes, close this application as well
            Application.Exit();
