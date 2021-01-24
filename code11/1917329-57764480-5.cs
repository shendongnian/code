    public static class Function1
    {
        public static string DBConn { get; set; }
        public static ILogger Log { get; set; }
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            Log = log;
            DBConn = "MySQLSrvrConnectionString";
            try
            {
                string spreadsheetId = "MyGoogleSheetId";
                
            }
            catch (Exception ex)
            {
                Log.LogInformation($"Error ({DateTime.Now.ToLongDateString()}): {ex.Message}");
            }
            finally
            {
                Log.LogInformation($"Function Completed at: {DateTime.Now.ToLongDateString()}");
            }
            return (ActionResult)new OkObjectResult($"");
        }
    }
