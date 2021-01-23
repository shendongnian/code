    public class BaseClass
    {
        
    }
    public class DerivedClass: BaseClass
    {
        
    }
    public static class BaseClassHelpers
    {
        public static T Method<T>(this T b) where T : BaseClass
        {
            return b;
        }
    }    
