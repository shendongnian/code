public static class DbContextExtensions
{
    public static bool IsPropertyNullableFor(this DbContext context, Type type, string propertyName)
    {
        var metadataWorkspace = ((IObjectContextAdapter) context).ObjectContext.MetadataWorkspace;
        var objectItemCollection = (ObjectItemCollection) metadataWorkspace.GetItemCollection(DataSpace.OSpace);
        var entityType = metadataWorkspace
            .GetItems<EntityType>(DataSpace.OSpace)
            .Single(e => objectItemCollection.GetClrType(e) == type);
        var entityContainer = metadataWorkspace.GetItems<EntityContainer>(DataSpace.CSpace)
            .Single()
            .EntitySets
            .Single(s => s.ElementType.Name == entityType.Name);
        var entityContainerMapping = metadataWorkspace
            .GetItems<EntityContainerMapping>(DataSpace.CSSpace)
            .Single()
            .EntitySetMappings
            .Single(s => s.EntitySet.Equals(entityContainer));
        var column = entityContainerMapping
            .EntityTypeMappings.Single()
            .Fragments.Single()
            .PropertyMappings
            .OfType<ScalarPropertyMapping>()
            .Single(m => m.Property.Name == propertyName).Column;
        return column.Nullable;
    }
}
Invoked like this:
Console.WriteLine("Is id nullable?: " + dbContext.IsPropertyNullableFor(typeof(MyClass), nameof(MyClass.Id)));
You could tighten up the interface with generics/expressions, this is just a demonstration of how to do it.
  [1]: https://docs.microsoft.com/en-us/ef/ef6/querying/raw-sql
  [2]: https://romiller.com/2015/08/05/ef6-1-get-mapping-between-properties-and-columns/
