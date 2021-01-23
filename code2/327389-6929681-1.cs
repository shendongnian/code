    public interface IBar
    {
    }
    public class foo
    {
        IBar myBar;
    }
    public class bar : IBar
    {
        foo myFoo;
    }
