    public class DbTableMeta
    {
        public string Schema { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Keys { get; set; }
    }
    public static DbTableMeta Meta(this DbContext context, Type type)
    {
        var metadata = ((IObjectContextAdapter) context).ObjectContext.MetadataWorkspace;
        // Get the part of the model that contains info about the actual CLR types
        var items = (ObjectItemCollection) metadata.GetItemCollection(DataSpace.OSpace);
        // Get the entity type from the model that maps to the CLR type
        var entityType = metadata
            .GetItems<EntityType>(DataSpace.OSpace)
            .Single(p => items.GetClrType(p) == type);
        // Get the entity set that uses this entity type
        var entitySet = metadata
            .GetItems<EntityContainer>(DataSpace.CSpace)
            .Single()
            .EntitySets
            .Single(p => p.ElementType.Name == entityType.Name);
        // Find the mapping between conceptual and storage model for this entity set
        var mapping = metadata.GetItems<EntityContainerMapping>(DataSpace.CSSpace)
            .Single()
            .EntitySetMappings
            .Single(p => p.EntitySet == entitySet);
        // Find the storage entity set (table) that the entity is mapped
        var table = mapping
            .EntityTypeMappings.Single()
            .Fragments.Single()
            .StoreEntitySet;
        return new DbTableMeta
        {
            Schema = (string) table.MetadataProperties["Schema"].Value ?? table.Schema,
            Name = (string) table.MetadataProperties["Table"].Value ?? table.Name,
            Keys = entityType.KeyMembers.Select(p => p.Name),
        };
    }
