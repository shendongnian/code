csharp
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text;
namespace GetChromeConsoleLog
{
    internal static class Program
    {
        private static void Main()
        {
            // setup options
            var options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            // do whatever actions
            var driver = new ChromeDriver(options)
            {
                Url = "https://www.yahoo.com/"
            };
            var logs = driver.GetBrowserLogs();
            // extract logs (using the extension method GetBrowserLogs)
            foreach (var log in driver.GetBrowserLogs())
            {
                Console.WriteLine($"{log["timestamp"]}: {log["message"]}");
            }
            // cleanup
            driver.Dispose();
            // hold console
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
    public static class WebDriverExtensions
    {
        public static IEnumerable<IDictionary<string, object>> GetBrowserLogs(this IWebDriver driver)
        {
            // not a chrome driver
            if(driver.GetType() != typeof(ChromeDriver))
            {
                return Array.Empty<IDictionary<string, object>>();
            }
            // setup
            var endpoint = GetEndpoint(driver);
            var session = GetSession(driver);
            var resource = $"{endpoint}session/{session}/se/log";
            const string jsonBody = @"{""type"":""browser""}";
            // execute
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync(resource, content).GetAwaiter().GetResult();
                var responseBody = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return AsLogEntries(responseBody);
            }
        }
        private static string GetEndpoint(IWebDriver driver)
        {
            // setup
            const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic;
            // get RemoteWebDriver type
            var remoteWebDriver = GetRemoteWebDriver(driver.GetType());
            // get this instance executor > get this instance internalExecutor
            var executor = remoteWebDriver.GetField("executor", Flags).GetValue(driver) as DriverServiceCommandExecutor;
            var internalExecutor = executor.GetType().GetField("internalExecutor", Flags).GetValue(executor) as HttpCommandExecutor;
            // get URL
            var uri = internalExecutor.GetType().GetField("remoteServerUri", Flags).GetValue(internalExecutor) as Uri;
            // result
            return uri.AbsoluteUri;
        }
        private static Type GetRemoteWebDriver(Type type)
        {
            if (!typeof(RemoteWebDriver).IsAssignableFrom(type))
            {
                return type;
            }
            while (type != typeof(RemoteWebDriver))
            {
                type = type.BaseType;
            }
            return type;
        }
        private static SessionId GetSession(IWebDriver driver)
        {
            if (driver is IHasSessionId id)
            {
                return id.SessionId;
            }
            return new SessionId($"gravity-{Guid.NewGuid()}");
        }
        private static IEnumerable<IDictionary<string, object>> AsLogEntries(string responseBody)
        {
            // setup
            var value = $"{JToken.Parse(responseBody)["value"]}";
            return JsonConvert.DeserializeObject<IEnumerable<Dictionary<string, object>>>(value);
        }
    }
}
[get logs][1]
  [1]: https://i.stack.imgur.com/Nxobn.png
