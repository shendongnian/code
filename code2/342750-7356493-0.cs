    public interface IHaveChildren<out T> where T:IHaveChildren<T>
    {
        /// <summary>Gets the children.</summary>
        IEnumerable<T> Children { get; }
    }
    public interface IHaveFamily<out T> : IHaveChildren<T> where T : IHaveChildren<T>
    {
        /// <summary>Gets the Parent.</summary>
        T Parent { get; }
    }
