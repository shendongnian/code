        public class MyJsonInputFormatter : JsonInputFormatter
        {
                public MyJsonInputFormatter(ILogger logger, JsonSerializerSettings serializerSettings, ArrayPool<char> charPool, ObjectPoolProvider objectPoolProvider, MvcOptions options, MvcJsonOptions jsonOptions) : base(logger, serializerSettings, charPool, objectPoolProvider, options, jsonOptions)
                {
                
                }
                public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
                {
                var result = await base.ReadRequestBodyAsync(context);
                if (result.Model is Movie movie && movie.IsSpecial)
                {
                        context.HttpContext.Request.Body.Position = 0;
                        string request = await new StreamReader(context.HttpContext.Request.Body).ReadToEndAsync();
                        var tickets = JObject.Parse(request)["Tickets"].ToObject<List<TicketSpecial>>();
                        movie.Tickets = tickets;
                }
                return result;
                }
        }
