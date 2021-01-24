    [FunctionName("Function1")]
    public static async Task<HttpResponseMessage> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequestMessage req,
        ILogger log)
    {
        var composeMessageList = new List<object>();
        for(var i = 0; i < 5; i++)
        {
            var composeMessage = new
            {
                __metadata = new
                {
                    id = "",
                    uri = "",
                    type = ""
                },
                dateForSystem = "2019-05-17",
                timeForSystem = "13:15:51"
            };
            composeMessageList.Add(composeMessage);
        }
        var jsonToReturn = JsonConvert.SerializeObject(composeMessageList);
        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
        };
    }
