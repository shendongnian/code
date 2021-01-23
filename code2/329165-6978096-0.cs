    public interface IDataAccessor
    {
        IList GetAllRecords();
        IFormEditor ShowAddEditForm();
        IList Collection { get; }
    }
    public interface IDataAccessor<T> : IDataAccessor
    {
        new IList<T> Collection { get; }
    }
