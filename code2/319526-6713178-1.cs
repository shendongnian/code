    public interface IDataErrorInfo
    {
        // Properties
        string Error { get; }
        string this[string columnName] { get; }
    }
 
