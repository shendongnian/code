    public static class StringExtensions
    {
        public static T FromJson<T>(this string source) where T : class
        {
            return JsonConvert.DeserializeObject<T>(source);
        }
    }
