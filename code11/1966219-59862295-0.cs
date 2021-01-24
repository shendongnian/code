    public sealed class TextColour
    {
        public string CssClass { get; }
    
        private static IDictionary<string, TextColour> _instances = new Dictionary<string, TextColour>();
    
        private TextColour(string cssClass)
        {
            CssClass = cssClass;
        }
    
        private static TextColour GetInstance(string cssClass)
        {
            if (!_instances.ContainsKey(cssClass))
            {
                _instances[cssClass] = new TextColour(cssClass);
            }
    
            return _instances[cssClass];
        }
    
        public static Primary => GetInstance("text-primary");
        public static Secondary => GetInstance("text-secondary");
    
        // Add others here
    }
