    /// <summary>
    /// Initializes global logging service
    /// </summary>
    private void InitLogger()
    {
      // Create configuration object 
      var Config = new LoggingConfiguration();
      // Create main target that continuously writes to the log file
      var FileTarget = new FileTarget("FileTarget")
      {
        FileName = "${basedir}/myservice.log",
        Layout = "${longdate} ${level} ${message}  ${exception}"
      };
      Config.AddTarget(FileTarget);
      //Create memory target that buffers log messages
      var MemTarget = new MemoryTarget("MemTarget");
      // Define rules
      Config.AddRuleForAllLevels(MemTarget);
      Config.AddRuleForAllLevels(FileTarget);
      // Activate the configuration
      LogManager.Configuration = Config;    
    }
