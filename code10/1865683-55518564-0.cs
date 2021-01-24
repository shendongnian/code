    public static IEnumerable<SqlBulkCopyColumnMapping> GetObjectNameColumnMappings()
        {
            return new[]
            {
                new SqlBulkCopyColumnMapping(nameof(propertyName), "dbColumnName"),
                new SqlBulkCopyColumnMapping(nameof(propertyName2), "dbColumnName2")
            };
        }
