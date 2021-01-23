    public interface ICriteria<T>
    {
       string Text { get; set; }
       IList<IParameter<T>> Parameters { get; set; }
    }
