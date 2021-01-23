    public interface IIndexable<T> : IEnumerable<T>
    {
        T this[int index] { get; }
        int Length { get; }
    }
