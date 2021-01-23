    public class UnsafeWrapper<UnsafeTypeName, SafeTypeName> 
            where UnsafeTypeName : SafeTypeName
        {
    
            private UnsafeTypeName gVariable;
    
            public SafeTypeName GetSafeVersion()
            {
                //Error falls on this line.
                return (SafeTypeName)gVariable;
            }
    
            public UnsafeTypeName GetUnsafeVersion()
            {
                return gVariable;
            }
    
        }
