    public interface IHasMethod<T>
    {
    	T MyMethod();
    }
    
    public abstract class ABase<T> : IHasMethod<T> ...
