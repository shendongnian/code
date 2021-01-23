        public static void Load(this DataTable table, IDataReader reader, bool createColumns)
        {
            if (createColumns)
            {
                table.Columns.Clear();
                var schemaTable = reader.GetSchemaTable();
                foreach (DataRowView row in schemaTable.DefaultView)
                {
                    var columnName = (string)row["ColumnName"];
                    var type = (Type)row["DataType"];
                    table.Columns.Add(columnName, type);
                }
            }
            table.Load(reader);
        }
