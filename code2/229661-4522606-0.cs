    public interface IPrimitive
    {
    
    }
    
    public interface IPrimitive<T> : IPrimitive
    {
         T Value { get; }
    }
    
    public class Star : IPrimitive<T> //must declare T here
    {
         
    }
