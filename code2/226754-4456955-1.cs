    [AttributeUsage(AttributeTargets.Class)]
    public class LoggingCategoryAttribute : Attribute
    {
        private readonly string _category;
    
        public LoggingCategoryAttribute(string category)
        {
            _category = category;
        }
    
        public string Category { get { return _category; } }
    }
