    public class JsonConfigFilterAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                var serializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                };
                var jsonFormatter = new JsonOutputFormatter(
                    serializerSettings, 
                    ArrayPool<char>.Shared);
                objectResult.Formatters.Add(jsonFormatter);
            }
            base.OnResultExecuting(context);
        }
    }
