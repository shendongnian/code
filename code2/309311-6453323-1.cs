    public interface IQueue<T> where T : IItem
    {
    }
    
    public class MyQueue<T> : IQueue<T>
        where T : IItem
    {
    }
