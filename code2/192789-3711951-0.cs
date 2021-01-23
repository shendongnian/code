    public class Functions
    {
        public static bool Like(string field, string value)
        {
            return true;
        }
        public static bool Like(decimal field, string value)
        {
            return true;
        }
    }
    public class FunctionMappings : FunctionMappingStore
    {
        public FunctionMappings()
            : base()
        {
            FunctionMapping mapping = new FunctionMapping(
                typeof(Functions), 
                "Like", 
                2, 
                "{0} LIKE {1}");
            this.Add(mapping);
        }
    }
