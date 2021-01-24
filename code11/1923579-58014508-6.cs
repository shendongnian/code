    public static string Serialize(object obj, Language lang)
    {
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new MultiLangResolver(lang),
            Formatting = Formatting.Indented
        };
        var json = JsonConvert.SerializeObject(obj, settings);
        return json;
    }
