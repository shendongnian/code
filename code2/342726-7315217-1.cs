    public class ClassOne : IPersistable
    {
    }
    public class ClassTwo : IPersistable
    {
    }
    //etc...
    public interface IPersistable
    {
        void SaveObject();
    }
