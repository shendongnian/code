    var settings = new JsonSerializerSettings
    {
        Converters = { new CustomDictionaryConverter(), new StringEnumConverter() }
    };
    var ds = JsonConvert.DeserializeObject<DeploymentSettings>(json, settings);
    var json2 = JsonConvert.SerializeObject(ds, Formatting.Indented, settings);
