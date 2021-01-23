    public static class JSONExts
    {
        public static string ToJSON(this object o)
        {
            var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return oSerializer.Serialize(o);
        }
        public static List<T> FromJSONToListOf<T>(this string jsonString)
        {
            var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return oSerializer.Deserialize<List<T>>(jsonString);
        }
        public static T FromJSONTo<T>(this string jsonString)
        {
            var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return oSerializer.Deserialize<T>(jsonString);
        }
        public static T1 ConvertViaJSON<T1>(this object o)
        {
            return o.ToJSON().FromJSONTo<T1>();
        }
    }
