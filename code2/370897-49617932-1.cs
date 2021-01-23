    public static JsonSerializerSettings StandardSerializerSettings => new JsonSerializerSettings
        {
            Converters = new List<JsonConverter>
            {
                new InterfaceConverter()
            }
        };
