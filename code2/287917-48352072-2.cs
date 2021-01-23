    public partial class YourEntities : DbContext
    {
        public async Task BulkInsertAllAsync<T>(IEnumerable<T> entities)
        {
            using (var conn = new SqlConnection(Database.Connection.ConnectionString))
            {
                await conn.OpenAsync();
                Type t = typeof(T);
                var bulkCopy = new SqlBulkCopy(conn)
                {
                    DestinationTableName = GetTableName(t)
                };
                var table = new DataTable();
                var properties = t.GetProperties().Where(p => p.PropertyType.IsValueType || p.PropertyType == typeof(string));
                foreach (var property in properties)
                {
                    Type propertyType = property.PropertyType;
                    if (propertyType.IsGenericType &&
                        propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        propertyType = Nullable.GetUnderlyingType(propertyType);
                    }
                    table.Columns.Add(new DataColumn(property.Name, propertyType));
                }
                foreach (var entity in entities)
                {
                    table.Rows.Add(
                        properties.Select(property => property.GetValue(entity, null) ?? DBNull.Value).ToArray());
                }
                bulkCopy.BulkCopyTimeout = 0;
                await bulkCopy.WriteToServerAsync(table);
            }
        }
        public void BulkInsertAll<T>(IEnumerable<T> entities)
        {
            using (var conn = new SqlConnection(Database.Connection.ConnectionString))
            {
                conn.Open();
                Type t = typeof(T);
                var bulkCopy = new SqlBulkCopy(conn)
                {
                    DestinationTableName = GetTableName(t)
                };
                var table = new DataTable();
                var properties = t.GetProperties().Where(p => p.PropertyType.IsValueType || p.PropertyType == typeof(string));
                foreach (var property in properties)
                {
                    Type propertyType = property.PropertyType;
                    if (propertyType.IsGenericType &&
                        propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        propertyType = Nullable.GetUnderlyingType(propertyType);
                    }
                    table.Columns.Add(new DataColumn(property.Name, propertyType));
                }
                foreach (var entity in entities)
                {
                    table.Rows.Add(
                        properties.Select(property => property.GetValue(entity, null) ?? DBNull.Value).ToArray());
                }
                bulkCopy.BulkCopyTimeout = 0;
                bulkCopy.WriteToServer(table);
            }
        }
        public string GetTableName(Type type)
        {
            var metadata = ((IObjectContextAdapter)this).ObjectContext.MetadataWorkspace;
            var objectItemCollection = ((ObjectItemCollection)metadata.GetItemCollection(DataSpace.OSpace));
            var entityType = metadata
                    .GetItems<EntityType>(DataSpace.OSpace)
                    .Single(e => objectItemCollection.GetClrType(e) == type);
            var entitySet = metadata
                .GetItems<EntityContainer>(DataSpace.CSpace)
                .Single()
                .EntitySets
                .Single(s => s.ElementType.Name == entityType.Name);
            var mapping = metadata.GetItems<EntityContainerMapping>(DataSpace.CSSpace)
                    .Single()
                    .EntitySetMappings
                    .Single(s => s.EntitySet == entitySet);
            var table = mapping
                .EntityTypeMappings.Single()
                .Fragments.Single()
                .StoreEntitySet;
            return (string)table.MetadataProperties["Table"].Value ?? table.Name;
        }
    }
