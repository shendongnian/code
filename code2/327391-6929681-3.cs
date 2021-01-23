    public interface IBar
    {
    }
    public class Foo
    {
        IBar myBar;
    }
    public class Bar : IBar
    {
        Foo myFoo;
    }
