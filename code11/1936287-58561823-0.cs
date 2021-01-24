    public static void Register(HttpConfiguration config)
    {
        config.MapHttpAttributeRoutes();
        config.Formatters.Remove(config.Formatters.XmlFormatter); 
        var jsonFormatter = config.Formatters.JsonFormatter;
        jsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
        jsonFormatter.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
        jsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        
        config.Routes.MapHttpRoute(
           name: "DefaultApi",
           routeTemplate: "api/{controller}/{id}",
           defaults: new { id = RouteParameter.Optional }
       );
    }
