    public void BulkInsert<TBusinessObject>(IEnumerable<TBusinessObject> entities, int timeoutInSeconds)
        where TBusinessObject : class, IBusinessObject
    {
        AssertUtilities.ArgumentAllNotNull(entities, "entities");
        AssertUtilities.ArgumentNotNegative(timeoutInSeconds, "timeoutInSeconds");
        var metaTable = Mapping.GetTable(typeof(TBusinessObject));
        if (metaTable == null)
            throw new DataAccessException("MetaTable is not found.");
        var insertDataMembers = metaTable.RowType.PersistentDataMembers
            .Where(arg => !arg.IsDbGenerated)
            .OrderBy(arg => arg.Ordinal)
            .ToList();
        using (var dataTable = new DataTable())
        {
            dataTable.Locale = CultureInfo.InvariantCulture;
            var dataColumns = insertDataMembers
                .Select(arg => new DataColumn(arg.MappedName))
                .ToArray();
            dataTable.Columns.AddRange(dataColumns);
            foreach (var entity in entities)
            {
                var itemArray = insertDataMembers
                    .Select(arg => arg.StorageAccessor.GetBoxedValue(entity))
                    .ToArray();
                dataTable.Rows.Add(itemArray);
            }
            try
            {
                if (Connection.State != ConnectionState.Open)
                    Connection.Open();
                var sqlConnection = (SqlConnection)Connection;
                var sqlTransaction = (SqlTransaction)Transaction;
                using (var bulkCopy = new SqlBulkCopy(sqlConnection, SqlBulkCopyOptions.Default, sqlTransaction))
                {
                    bulkCopy.BulkCopyTimeout = timeoutInSeconds;
                    bulkCopy.DestinationTableName = metaTable.TableName;
                    foreach (var dataColumn in dataColumns)
                        bulkCopy.ColumnMappings.Add(dataColumn.ColumnName, dataColumn.ColumnName);
                    bulkCopy.WriteToServer(dataTable);
                }
            }
            catch (Exception exception)
            {
                throw DataAccessExceptionTranslator.Translate(exception);
            }
        }
    }
