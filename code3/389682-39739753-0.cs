    public void DoIt<T>(T some) where T : IMyClass
    {
    }
...
    public interface IMyClass
    {
    }
    public class Type1 : IMyClass
    {
    }
    public class Type2 : IMyClass
    {
    }
