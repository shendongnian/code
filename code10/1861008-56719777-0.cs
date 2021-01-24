c#
var config = new LoggingConfiguration();
config.AddRuleForAllLevels(new DatabaseTarget()
{
    ConnectionString = "MyConnectionString",
    CommandText = "INSERT .... ", //todo
    Parameters =
    {
        new DatabaseParameterInfo("@message", "${message}"),
        new DatabaseParameterInfo("@error", "${exception}"),
        new DatabaseParameterInfo("@date", "${date}"){ DbType = "DbType.Date"},
    }
});
LogManager.Configuration = config; // Apply config
