        public class ModelStateJsonInputFormatter : JsonInputFormatter
        {
            public ModelStateJsonInputFormatter(ILogger<ModelStateJsonInputFormatter> logger, JsonSerializerSettings serializerSettings, ArrayPool<char> charPool, ObjectPoolProvider objectPoolProvider, MvcOptions options, MvcJsonOptions jsonOptions) : base(logger, serializerSettings, charPool, objectPoolProvider, options, jsonOptions)
            {
            }
            public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
            {
                var result = await base.ReadRequestBodyAsync(context);
                foreach (var property in context.ModelType.GetProperties())
                {
                    var propValue = property.GetValue(result.Model, null);
                    var propAttemptValue = property.GetValue(result.Model, null)?.ToString();
                    context.ModelState.SetModelValue(property.Name, propValue, propAttemptValue);
                }
                return result;
            }
        }
