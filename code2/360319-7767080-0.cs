    public interface IFoo
    {
        string MyReadonlyString { get; }
    } 
    public class FooImplementation : IFoo
    {
        public string MyReadonlyString { get; private set; }
    }
