    static class TypeResolver
    {
        static Dictionary<TableDataType, Type> typeLookup = new Dictionary<TableDataType, Type>();
    
        static TypeResolver()
        {
            typeLookup.Add(TableDataType.Integer, typeof(Int32));
            typeLookup.Add(TableDataType.String, typeof(String));
        }
    
        public static Type Resolve(TableDataType tableType)
        {
            return typeLookup[tableType];
        }
    }
