    [FunctionName("Function1")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req,
        ILogger log)
    {
        var reservationDraftRequestDto = req.DeserializeModel<ReservationDraftRequestDto>();
        var data = JsonConvert.SerializeObject(reservationDraftRequestDto);
        //more logic...
        return new OkResult();
    }
    public static T DeserializeModel<T>(this HttpRequest request)
    {
        using (var reader = new StreamReader(request.Body))
        using (var textReader = new JsonTextReader(reader))
        {
            request.Body.Seek(0, SeekOrigin.Begin);
            var serializer = JsonSerializer.Create(new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            return serializer.Deserialize<T>(textReader);
        }
    }
