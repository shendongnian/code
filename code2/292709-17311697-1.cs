    var cols = from meta in ctx.MetadataWorkspace.GetItems(DataSpace.CSpace)
                           .Where(m=> m.BuiltInTypeKind==BuiltInTypeKind.EntityType)
                        from p in (meta as EntityType).Properties
                           .Where(p => p.DeclaringType.Name == "EntityName")
                       select new
                          {
                           PropertyName = p.Name,
                           TypeUsageName = p.TypeUsage.EdmType.Name, //type name
                           Documentation = p.Documentation != null ?               
                                           p.Documentation.LongDescription : null //if primary key
            };
