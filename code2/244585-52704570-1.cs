    public static class ObjectExtensions
    {
        public static string ToJson(this object source)
        {
            return JsonConvert.SerializeObject(source, Formatting.None);
        }
    }
