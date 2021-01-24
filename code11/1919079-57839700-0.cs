     public class CustomJsonOutputFormatter : JsonOutputFormatter
        {
            public CustomJsonOutputFormatter(JsonSerializerSettings serializerSettings, ArrayPool<char> charPool)
                : base(serializerSettings, charPool)
            { }
    
            public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
            {
                var @object = CResponse.Generate(context.Object, (HttpStatusCode)context.HttpContext.Response.StatusCode);
    
                var newContext = new OutputFormatterWriteContext(context.HttpContext, context.WriterFactory, typeof(CResponse), @object);
                newContext.ContentType = context.ContentType;
                newContext.ContentTypeIsServerDefined = context.ContentTypeIsServerDefined;
    
                return base.WriteResponseBodyAsync(newContext, selectedEncoding);
   
            }
        }
