    public class FOO
    {
    }
    public interface IObjectSet
    {
    }
    
    public class ObjectSet<T> : IObjectSet
    {
    }
    
    IObjectSet get =  MyConvert<FOO>(new ObjectSet<FOO>());
