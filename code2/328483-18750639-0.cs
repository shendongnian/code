    string repoName = String.Format("{0}Repository", logFileName);
            
    // Check for existing repository
    ILoggerRepository[] allRepos = LogManager.GetAllRepositories();
    ILoggerRepository repo = allRepos.Where(x => x.Name == repoName).FirstOrDefault();
    // If repository does not exist, create one, set the logfile name, and configure it
    if (repo == null)
    {
        repo = LogManager.CreateRepository(repoName);
        ThreadContext.Properties[KEY_LOG_FILE] = logFileName;
        log4net.Config.XmlConfigurator.Configure(repo);
    }
    // Set logger
    ILog logger = LogManager.GetLogger(repoName, logName);
