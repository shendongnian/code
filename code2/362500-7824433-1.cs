    namespace ExtensionMethods 
    { 
        public static class MyExtensions 
        { 
            public static bool IsNullOrWhiteSpace(this String str) 
            { 
                return string.IsNullOrWhiteSpace(str);
            } 
        }    
    } 
