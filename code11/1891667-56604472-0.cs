C#
var basePath = Environment.GetEnvironmentVariable("AzureWebJobsScriptRoot")
    ?? $"{Environment.GetEnvironmentVariable("HOME")}/site/wwwroot";
            
var config = new ConfigurationBuilder()
        .SetBasePath(basePath)
        .AddJsonFile("local.settings.json", optional: true, reloadOnChange: false)
        .AddEnvironmentVariables()
        .Build();
Here's the code for getting AppSetting and ConnectionString:
C#
public static string GetAppSetting(string name)
{
    return ConfigurationRoot?[name]
        ?? ConfigurationRoot?["Values:" + name]
        ?? ConfigurationRoot?["APPSETTING_" + name]
        ?? ConfigurationManager.AppSettings[name];
}
public static string GetConnectionString(string name)
{
    return ConfigurationRoot?.GetConnectionString(name)
        ?? ConfigurationRoot?.GetConnectionString("SQLAZURECONNSTR_" + name)
        ?? ConfigurationManager.ConnectionStrings[name].ConnectionString;
}
