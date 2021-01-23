    int Main(string[] args)
    {
       string currentExecutable = Assembly.GetExecutingAssembly().Location;
    
       bool inChild = false;
       List<string> xargs = new List<string>();
       foreach (string arg in xargs)
       {
          if (arg.Equals("-child"))
          {
             inChild = true;
          }
          /* Parse other command line arguments */
          else
          {
             xargs.Add(arg);
          }
       }
    
       if (!inChild)
       {
          AppDomainSetup info = new AppDomainSetup();
          info.ConfigurationFile = /* Path to desired App.Config File */;
          Evidence evidence = AppDomain.CurrentDomain.Evidence;
          AppDomain domain = AppDomain.CreateDomain(friendlyName, evidence, info);
    
          xargs.Add("-child"); // Prevent recursion
    
          return domain.ExecuteAssembly(currentExecutable, evidence, xargs.ToArray());
       }
    
       // Execute actual Main-Code, we are in the child domain with the custom app.config
    
       return 0;
    }
