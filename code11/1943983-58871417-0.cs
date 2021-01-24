#r "Newtonsoft.Json"
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Threading;
public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("do what you want before the job");
    DoYourJob(log);  //do your job in this method
    return new OkResult();  //return 200 status to slack
}
public static async void DoYourJob(ILogger log)
{
    await Task.Run(() =>
    {
        log.LogInformation("do your job, it can be completed more than 3 seconds");
        //Thread.Sleep(3000);
    });
}
Hope it would be helpful to your requirement~
