var config = new LoggingConfiguration();
//ensure that log output is seen in the Streamed Log window
config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, 
     new MicrosoftILoggerTarget(azureLog)));
//ensure that log output is sent to Application Insights
config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, 
     new ApplicationInsightsTarget()));
LogManager.Configuration = config;
var nlog = LogManager.GetLogger("Example");
nlog.Info("output from nlog");
where azureLog is the **ILogger** provided to the Run method of the function.
**MicrosoftILoggerTarget** can be found in the NLog.Extensions.Logging nuget package.
