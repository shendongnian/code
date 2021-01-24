csharp
public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(o => { })
                .AddJsonOptions(s =>
                {
                    s.SerializerSettings.Converters.Add(new Converter()); // one way to gain more control will be to use custom converter for your type, see implementation down below
                    //if you are after something a bit more simple, setting behaviours and handling general error events might work too
                    s.SerializerSettings.MissingMemberHandling = MissingMemberHandling.Error; // you probably want that so your missing 
                    s.SerializerSettings.Error = delegate(object sender, ErrorEventArgs args)
                    {
                        // throw your custom exceptions here
                        var message = args.ErrorContext.Error.Message;
                        args.ErrorContext.Handled = false;
                    };
                });
        }
implementing Converter is fairly easy:
csharp
    class Converter : JsonConverter<LoginRequest>
    {
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, LoginRequest value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override LoginRequest ReadJson(JsonReader reader, Type objectType, LoginRequest existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // your logic here
        }
    }
--------
**UPD** after getting a better view of your specific requirement re handling primitive types it seems trying to fiddle with MVC serialiser gets a bit too cumbersome. Reason being, the level of control you're after (especially checking primitive types ) seems to be available on `JsonTextReader` level, but it seems overriding that would mean reimplementing a significant chunk of library code:
csharp
services.AddMvc(o =>
            {
                o.InputFormatters.RemoveType<JsonInputFormatter>();
                o.InputFormatters.Add(new MyJsonInputFormatter(logger, serializerSettings, charPool, objectPoolProvider));// there are quite a few parameters that you need to source from somewhere before instantiating your formatter. 
            })
....
class MyJsonInputFormatter: JsonInputFormatter {
    public override async Task<InputFormatterResult> ReadRequestBodyAsync(
      InputFormatterContext context,
      Encoding encoding)
    {
        ...your whole implementation here...
    }
}
Therefore I think the most viable approach would be injecting custom middleware before MVC and doing something along the lines of [schema validation][1] for your raw json. Since MVC **will** need to re-read your json again (for model binding etc), you would want to check out my other [answer](https://stackoverflow.com/questions/59598589/asp-net-core3-0-webapi-request-body-and-frombody-conflict/59605982) that caters for request steam rewinding.
  [1]: https://www.newtonsoft.com/json/help/html/JsonSchema.htm
