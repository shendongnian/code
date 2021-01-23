    public interface IMyInterface
    {
        void SomeFunction();
    }
    public interface IMyInterface<T> : IMyInterface
    {
        T Value { get; set; }
    }
