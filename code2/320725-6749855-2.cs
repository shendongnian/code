    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDisplayNameAttribute : System.Attribute
    {
        public string DisplayName { get; set; }
        public EnumDisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }
