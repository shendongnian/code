    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            var json = config.Formatters.JsonFormatter;
            var serializerSettings = json.SerializerSettings;
            var contractResolver = (Newtonsoft.Json.Serialization.DefaultContractResolver)serializerSettings.ContractResolver;
            serializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            serializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
            contractResolver.IgnoreSerializableInterface = true;
            contractResolver.IgnoreSerializableAttribute = true;
        }
    }
