    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        static string Localize(string key)
        {
            return YourResourceClassName.ResourceManager.GetString(key);
        }
        public LocalizedDescriptionAttribute(string key)
            : base(Localize(key))
        {
        }
    }
