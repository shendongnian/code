c#
// Load NLog
NLog.Web.NLogBuilder.ConfigureNLog("nlog.config");
// Create provider to bridge Microsoft.Extensions.Logging
var provider = new NLog.Extensions.Logging.NLogLoggerProvider();
// Create logger
Microsoft.Extensions.Logging.ILogger logger = provider.CreateLogger(typeof(MyClass).FullName);
Please note, you can't create a `Microsoft.Extensions.Logging.ILogger<MyClass>` this way! Just a non-generic `Microsoft.Extensions.Logging.ILogger`. If you need the generic version, then you need the DI setup and that will handle the conversion between both. 
### NLog.config and test projects
Also good to know, finding a nlog.config in a test project is hard, as unit test frameworks will move the binaries etc. I would recommend to use the config API
e.g.
c#
var configuration = new LoggingConfiguration();
configuration.AddRuleForAllLevels(new ConsoleTarget());
NLog.Web.NLogBuilder.ConfigureNLog(configuration);
OR 
c#
var configuration = XmlLoggingConfiguration.CreateFromXmlString("<nlog>....</nlog>"); //full nlog.config as string
NLog.Web.NLogBuilder.ConfigureNLog(configuration);
