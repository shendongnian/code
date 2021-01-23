    public class UniqueAttribute : Attribute
    {
        public UniqueAttribute(string uniqueKey)
        {
            UniqueKey = uniqueKey;
        }
        public string UniqueKey { get; set; }
        public string GetKey()
        {
            return string.Concat(UniqueKey, "Unique");
        }
    }
