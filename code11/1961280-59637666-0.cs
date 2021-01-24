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
