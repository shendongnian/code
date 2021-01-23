    public class Thing
    {
        public int Id;
    }
    public class User: Thing
    {
        public string Email; 
    }
    public class Computer : Thing 
    {    
        public string Name; 
    } 
    private static void RewriteIListIds<T>(ref IList<T> pre, IList<T> post) where T: Thing
