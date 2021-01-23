     private EntitySet GetEntitySet<T>(DbContext context)
    {
        var type = typeof(T);
        var entityName = type.Name;
        var metadata = ((IObjectContextAdapter)context).ObjectContext..MetadataWorkspace;
 
        IEnumerable<EntitySet> entitySets;
        entitySets = metadata.GetItemCollection(DataSpace.SSpace)
                         .GetItems<EntityContainer>()
                         .Single()
                         .BaseEntitySets
                         .OfType<EntitySet>()
                         .Where(s => !s.MetadataProperties.Contains("Type")
                                     || s.MetadataProperties["Type"].ToString() == "Tables");
        var entitySet = entitySets.FirstOrDefault(t => t.Name == entityName);
        return entitySet;
    }
