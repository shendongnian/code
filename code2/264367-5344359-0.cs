    // Results = DataSet
    foreach (DataTable table in results.Tables)
    {
        Console.WriteLine("Table: " + table.TableName);
        foreach (DataRow row in table.Rows)
        {
            Console.WriteLine("  Row");
            foreach (DataColumn column in table.Columns)
            {
                Console.WriteLine("    " + column.ColumnName + ": " +
                    row[column]);
            }
        }
    }
