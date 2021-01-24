    public interface IConfigurator<T>
    {
         string TableName { get; }
         PropertyMapper<T> PropertyMap { get; }
         object ParentConfigurator {get;set;} 
    }
