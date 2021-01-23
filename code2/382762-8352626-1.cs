    // Parameter types as before
    public interface ICriteria
    {
        string Text { get; set; }
        IEnumerable<IParameter> Parameters { get; }
    }
    public interface ICriteria<T> : ICriteria
    {
        new IList<IParameter<T>> Parameters { get; }
    }
