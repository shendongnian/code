    public interface IParameter
    {
        // Any members which don't need T
    }
    public interface IParameter<T> : IParameter
    {
        // Any members which do need to refer to T
    }
    public interface ICriteria
    {
        string Text { get; set; }
        IEnumerable<IParameter> WeakParameters { get; }
    }
    public interface ICriteria<T> : ICriteria
    {
        IList<IParameter<T>> StrongParameters { get; }
    }
