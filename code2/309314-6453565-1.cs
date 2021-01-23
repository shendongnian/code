    public class Coordinator<T> where T : IQueue<T>, new()
    {
        private T collection = new T();  
    }
    public interface IQueue<T>{}
    public interface IItem{}
