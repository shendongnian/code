c#
public class CategoryMap : ClassMapping<Category>
{
    public CategoryMap()
    {
        Tables("Categories");
        Id(x => x.CategoryID);
        // In db this column's type is image
        // while the property type is byte[] so this explicit property map is needed
        Property(x => x.Picture, m => m.Type(new BinaryBlobType()));
    }
}
Part of my config (in the same Program class, the rest are omitted for brevity)
c#
...
// Unlike ModelMapper, this mapper automatically maps class name -> table, property -> column
var mapper = new ConventionModelMapper();
mapper.AddMapping<CategoryMap>();
var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
config.AddMapping(mapping);
...
