    #r "Newtonsoft.Json"
    
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Primitives;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    
    public static string DBConn = "123456";
    public static ILogger Log = null;
    
    public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
    {
        Log=log;  
        DBConn="MySQLSrvrConnectionString";
        try
        {
            string spreadsheetId = "MyGoogleSheetId";
            //SheetsService service = GetSheetService();
            //if(service!=null)
            //{
            //    DoSomethingFunc(GetInsertCommand(GetSheetVals(service,spreadsheetId)));
            //}
        }
        catch (Exception ex)
        {
            Log.LogInformation($"Error ({DateTime.Now.ToLongDateString()}): {ex.Message}");
        }
        finally
        {
            Log.LogInformation($"Function Completed at: {DateTime.Now.ToLongDateString()}");
        }
        string name = req.Query["name"];
    
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        dynamic data = JsonConvert.DeserializeObject(requestBody);
        name = name ?? data?.name;
    
        return name != null
            ? (ActionResult)new OkObjectResult($"Hello, {name}")
            : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
    }
