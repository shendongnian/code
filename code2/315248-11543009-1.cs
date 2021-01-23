     private string GetTableName(DbEntityEntry ent)
            {
                ObjectContext objectContext = ((IObjectContextAdapter) this).ObjectContext;
                Type entityType = ent.Entity.GetType();
    
                if (entityType.BaseType != null && entityType.Namespace == "System.Data.Entity.DynamicProxies")
                    entityType = entityType.BaseType;
                
                string entityTypeName = entityType.Name;
    
                EntityContainer container =
                    objectContext.MetadataWorkspace.GetEntityContainer(objectContext.DefaultContainerName, DataSpace.CSpace);
                string entitySetName = (from meta in container.BaseEntitySets
                                        where meta.ElementType.Name == entityTypeName
                                        select meta.Name).First();
                return entitySetName;
            }
