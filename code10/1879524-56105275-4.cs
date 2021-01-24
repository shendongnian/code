    public interface IConfigurator<T,TParent>
    {
         string TableName { get; }
         PropertyMapper<T> PropertyMap { get; }
         IConfigurator<TParent,??> ParentConfigurator { get; } // what are you going to put here for ?? object maybe
    }
