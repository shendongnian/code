    public interface IModelConverter<TSourceModel, TDestinationModel>
    {
        IEnumerable<TDestinationModel> ToDestination(IEnumerable<TSourceModel> source);
        IEnumerable<TDestinationModel>ToSource(IEnumerable<TDestinationModel> source);
        //...
    }
    var fooList = new List<Foo>(modelConverter.ToDestination(booList);
