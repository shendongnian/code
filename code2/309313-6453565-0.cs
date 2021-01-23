    public class Coordinator<T> where T : IQueue<T>
    {
        // private T collection = new T();  // note we can't construct an interface, we must supply an instance.  So, perhaps you are looking for classes that implement IQueue<T> and IItem instead + supply this as T.
    }
    public interface IQueue<T>{}
    public interface IItem{}
