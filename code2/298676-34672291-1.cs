    public static string SerializeToLogJson(this object obj)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(obj,
                        Newtonsoft.Json.Formatting.None, 
                        new JsonSerializerSettings { 
                            NullValueHandling = NullValueHandling.Ignore,
                            Formatting = Formatting.Indented
                        });
                    return json;
                }
                catch (Exception e)
                {
                    log.ErrorFormat(e.Message, e);
                    return "Cannot serialize: " + e.Message;
                }
            }
