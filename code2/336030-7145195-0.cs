    public interface IValueProvider
    {
        object Value { get; }
    }
    public interface IValueProvider<T> : IValueProvider
    {
        new T Value{get; }
    }
