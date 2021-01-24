    #r "Newtonsoft.Json"
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Primitives;
    using Newtonsoft.Json;
    using Microsoft.Extensions.Configuration;
    public static async Task<string> Run(HttpRequest req, ILogger log) {
    var app_setting = System.Environment.GetEnvironmentVariable("MyAppSetting");
    return app_setting;
}
