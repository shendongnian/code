    public interface IConfigurator<T>
    {
         string TableName { get; }
         PropertyMapper<T> PropertyMap { get; }
    }
    public interface IConfigurator<T,TParent> : IConfigurator<T>
    {
       IConfigurator<TParent> ParentConfigurator { get; } // what are you going to put here for ?? object maybe
    }
