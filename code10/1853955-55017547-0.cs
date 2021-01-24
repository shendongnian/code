    public class DateTimeOffSetJsonInputFormatter : JsonInputFormatter
    {
        private readonly JsonSerializerSettings _serializerSettings;
        public DateTimeOffSetJsonInputFormatter(ILogger logger
            , JsonSerializerSettings serializerSettings
            , ArrayPool<char> charPool
            , ObjectPoolProvider objectPoolProvider
            , MvcOptions options
            , MvcJsonOptions jsonOptions) 
                : base(logger, serializerSettings, charPool, objectPoolProvider, options, jsonOptions)
        {
            _serializerSettings = serializerSettings;
        }
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            var request = context.HttpContext.Request;
            using (var reader = new StreamReader(request.Body))
            {
                var content = await reader.ReadToEndAsync();
                var resource = JObject.Parse(content);
                var result = JsonConvert.DeserializeObject(resource.ToString(), context.ModelType);
                foreach (var property in result.GetType().GetProperties())
                {
                    if (property.PropertyType == typeof(DateTimeOffset))
                    {
                        property.SetValue(result, DateTimeOffset.Parse(resource[property.Name].ToString()));
                    }
                }
                return await InputFormatterResult.SuccessAsync(result);
            }
        }
    }
