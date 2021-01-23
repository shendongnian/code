    public static void SetLogger(string pathName, string pattern)
            {
                Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
    
                PatternLayout patternLayout = new PatternLayout();
                patternLayout.ConversionPattern = pattern;
                patternLayout.ActivateOptions();
    
                RollingFileAppender roller = new RollingFileAppender();
                roller.AppendToFile = false;
                roller.File = pathName;
                roller.Layout = patternLayout;
                roller.MaxSizeRollBackups = 5;
                roller.MaximumFileSize = "1GB";
                roller.RollingStyle = RollingFileAppender.RollingMode.Size;
                roller.StaticLogFileName = true;
                roller.ActivateOptions();
                hierarchy.Root.AddAppender(roller);
    
                MemoryAppender memory = new MemoryAppender();
                memory.ActivateOptions();
                hierarchy.Root.AddAppender(memory);
    
                hierarchy.Root.Level = log4net.Core.Level.Info;
                hierarchy.Configured = true;
          }
