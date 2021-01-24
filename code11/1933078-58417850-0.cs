    public interface IDependency
    {
        // Actual, useful interface definition
    }
    public interface IFasterDependency : IDependency
    {
        // You don't actually have to define anything here
    }
    public class SlowClass : IDependency
    {
    
    }
    // FasterClass is now a IDependencyObject, but has its own interface 
    // so you can register it in your dependency injection
    public class FasterClass : IFasterDependency
    {
    }
