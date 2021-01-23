     public static class JsonExtentions
        {
            public static string SerializeToJson(this object SourceObject) { return Newtonsoft.Json.JsonConvert.SerializeObject(SourceObject); }
    
           
            public static T JsonToObject<T>(this string JsonString) { return (T)Newtonsoft.Json.JsonConvert.DeserializeObject<T>(JsonString); }
    }
