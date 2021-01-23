    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    
        ...
        private static string Format(string jsonString)
        {
            try
            {
                return JToken.Parse(jsonString).ToString(Formatting.Indented);
            }
            catch
            {
                return jsonString;
            }
        }
