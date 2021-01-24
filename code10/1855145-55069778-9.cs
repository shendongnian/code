    public interface IStack<out T>
    {
        bool IsEmpty { get; }
        IStack<T> Pop();
        T Peek();
