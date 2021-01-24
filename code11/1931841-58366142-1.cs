c#
static void Main(string[] args)
{
    UpdateNLogConfig();
    LogManager.ConfigurationReloaded += LogManager_ConfigurationReloaded;
    log.Info("Entering Application.");
    Console.WriteLine("Press any key to exit ...");
    Console.Read();
}
private static void LogManager_ConfigurationReloaded(object sender, LoggingConfigurationReloadedEventArgs e)
{
    UpdateNLogConfig();
}
private static void UpdateNLogConfig()
{
    //note: don't set  LogManager.Configuration because that will overwrite the nlog.config settings
    var target = (FileTarget)LogManager.Configuration.FindTargetByName<AsyncTargetWrapper>("logfile").WrappedTarget;
    target.FileName = $@"..\..\..\..\logs\Foobar.log";   
    LogManager.ReconfigExistingLoggers();
}
See also [Combine XML config with C# config · NLog/NLog Wiki](https://github.com/NLog/NLog/wiki/Combine-XML-config-with-C%23-config)
