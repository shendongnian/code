    public sealed class StrongProperty<TObject, TProperty> {
       readonly PropertyInfo mPropertyInfo;
       public string Name => mPropertyInfo.Name;
       public Func<TObject, TProperty> Get { get; }
       public Action<TObject, TProperty> Set { get; }
       // maybe other useful properties
       internal StrongProperty(
          PropertyInfo pPropertyInfo,
          Func<TObject, TProperty> pGet,
          Action<TObject, TProperty> pSet
       ) {
          mPropertyInfo = pPropertyInfo;
          Get = pGet;
          Set = pSet;
       }
    }
