    public interface ILoadObjects<T> : ILoadObjects where T : class
    {
        List<T> LoadBySearch();
    }
    public interface ILoadObjects
    {
        IList LoadBySearch();
    }
