    public static class BindingFlagsHelper
    {
        public static BindingFlags GetAllMethods()
        {
            return 
                BindingFlags.NonPublic | 
                BindingFlags.DeclaredOnly | 
                BindingFlags.Public | 
                BindingFlags.Instance | BindingFlags.Static;
        }
    }
