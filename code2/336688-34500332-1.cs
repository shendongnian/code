    private static List<string> GetColumnNamesFromTableSchema(IDataReader reader)
        {
            var schemaTable = reader.GetSchemaTable();
            var columnNames = new List<string>();
            if (schemaTable != null)
                columnNames.AddRange(from DataRow row in schemaTable.Rows select row["ColumnName"].ToString());
            return columnNames;
        }
