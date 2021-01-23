    protected JsonNetResult JsonNet(object data, bool needDefaultSettings)
            {
                var result = new JsonNetResult();
                result.Data = data;
    
                if (needDefaultSettings)
                {
                    var defaultSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        DefaultValueHandling = DefaultValueHandling.Ignore
                    };
                    result.SerializerSettings = defaultSettings;
                }
    
                return result;
            }
