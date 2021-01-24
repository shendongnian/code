        public class IgnoreGuidErrorJsonInputFormatter : JsonInputFormatter
        {
            public IgnoreGuidErrorJsonInputFormatter(ILogger logger, JsonSerializerSettings serializerSettings, ArrayPool<char> charPool, ObjectPoolProvider objectPoolProvider, MvcOptions options, MvcJsonOptions jsonOptions) : base(logger, serializerSettings, charPool, objectPoolProvider, options, jsonOptions)
            {
                serializerSettings.Error = (a, e) =>
                {
                    var errors = e.ErrorContext.Error;
                    e.ErrorContext.Handled = true;
                };
            }
        }
