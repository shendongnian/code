    public class CollectionAccessConvention : ICollectionConvention
    {
        public void Apply(ICollectionInstance instance)
        {
            instance.Fetch.Join();
            instance.Not.LazyLoad();
            instance.Access.CamelCaseField(CamelCasePrefix.Underscore);
        }
    }
