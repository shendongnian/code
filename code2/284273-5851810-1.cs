    using (var context = new ModelContainer())
    {
        // Access CSDL
        var container = context.MetadataWorkspace
                               .GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace);
        // Access name of related set exposed on your context
        var set = container.BaseEntitySets[context.YourEntitySet.EntitySet.Name];
        // Access all properties
        var properties = set.ElementType.Members.Select(m => m.Name).ToList();
        // Access only keys
        var keys = set.ElementType.KeyMembers.Select(m => m.Name).ToList();
    }
