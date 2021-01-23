    public void DoIt<T>(T someParameter) where T : IMyType
    {
    }
...
    public interface IMyType
    {
    }
    public class Type1 : IMyType
    {
    }
    public class Type2 : IMyType
    {
    }
