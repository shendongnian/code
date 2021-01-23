    public interface IFoo
    {
        string PropA { get; set; }
    }
    public interface IFooExtended
    {
        void MyMethod();
    }
    public class ConcreteFoo : IFooExtended
    {
        // implementation...
    }
