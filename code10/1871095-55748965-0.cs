    public static void Register(HttpConfiguration config)
    {
        var jsonFormatter = config.Formatters.JsonFormatter;
        jsonFormatter.SerializerSettings.DateParseHandling = Newtonsoft.Json.DateParseHandling.None;
    }
