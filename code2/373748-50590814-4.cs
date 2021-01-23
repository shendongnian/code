    public sealed class StrongProperty<TObject, TProperty> {
       [NotNull] readonly PropertyInfo mPropertyInfo;
       [NotNull] public string Name => mPropertyInfo.Name;
       [NotNull] public Func<TObject, TProperty> Get { get; }
       [NotNull] public Action<TObject, TProperty> Set { get; }
       // maybe other useful properties
       internal StrongProperty(
          [NotNull] PropertyInfo pPropertyInfo,
          [NotNull] Func<TObject, TProperty> pGet,
          [NotNull] Action<TObject, TProperty> pSet
       ) {
          mPropertyInfo = pPropertyInfo;
          Get = pGet;
          Set = pSet;
       }
    }
