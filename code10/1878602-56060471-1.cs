    public class BulkWriter
    {
    		private static readonly ConcurrentDictionary<Type, SqlBulkCopyColumnMapping[]> ColumnMapping =
    			new ConcurrentDictionary<Type, SqlBulkCopyColumnMapping[]>();
    
    		public async Task InsertAsync<T>(IEnumerable<T> items, string tableName, SqlConnection connection,
    			CancellationToken cancellationToken)
    		{
                using (var bulk = new SqlBulkCopy(connection))
                using (var reader = ObjectReader.Create(items))
                {
                    bulk.DestinationTableName = tableName;
                    foreach (var colMap in GetColumnMappings<T>())
                        bulk.ColumnMappings.Add(colMap);
                    await bulk.WriteToServerAsync(reader, cancellationToken);
                }
    		}
    
    		private static IEnumerable<SqlBulkCopyColumnMapping> GetColumnMappings<T>() =>
    			ColumnMapping.GetOrAdd(typeof(T),
    				type => 
    					type.GetProperties()
    						.Select(p => new SqlBulkCopyColumnMapping(p.Name, p.Name)).ToArray());
    }
