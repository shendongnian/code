    using System.Configuration;
    Config.SessionKillConfig config = null;
    try {
        config = (Config.SessionKillConfig)ConfigurationManager.GetSection("CdrAnalyzerConfig");
    } catch (System.Configuration.ConfigurationException ex) {
        syslog.Fatal("Loading parser configuration failed", ex);
        return;
    }
    if(config.Enabled) { //do stuff }
