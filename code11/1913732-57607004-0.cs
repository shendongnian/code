    public interface IDataAdapter 
    {
       void InsertValue(object value);
       Type SupportedType { get; }
    }
