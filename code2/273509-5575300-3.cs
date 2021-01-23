    private static readonly log4net.ILog log = log4net.LogManager.GetLogger(
        System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public void LogError(string message)
    {
        log.Error(Program.LogPrefix +"\r\r\nERROR:" + message);
    }
    public void LogAudit(string message)
    {
        log.Debug(Program.LogPrefix + "\r\r\nINFO:" + message);
    }
