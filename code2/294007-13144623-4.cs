    public static void ClearDatabase(DbContext context)
        {
            var objectContext = ((IObjectContextAdapter)context).ObjectContext;
            var entities = objectContext.MetadataWorkspace.GetEntityContainer(objectContext.DefaultContainerName, DataSpace.CSpace).BaseEntitySets;
            var method = objectContext.GetType().GetMethods().First(x => x.Name == "CreateObjectSet");
            var objectSets = entities.Select(x => method.MakeGenericMethod(Type.GetType(x.ElementType.FullName))).Select(x => x.Invoke(objectContext, null));
            var tableNames = objectSets.Select(objectSet => (objectSet.GetType().GetProperty("EntitySet").GetValue(objectSet, null) as EntitySet).Name).ToList();
            foreach (var tableName in tableNames)
            {
                context.Database.ExecuteSqlCommand(string.Format("DELETE FROM {0}", tableName));
            }
            context.SaveChanges();
        }
