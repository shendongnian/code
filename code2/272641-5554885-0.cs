    static void GetSchemaInfo(SqlConnection connection)
    {
        using (connection)
        {
            SqlCommand command = new SqlCommand(
              "SELECT CategoryID, CategoryName FROM Categories;",
              connection);
            connection.Open();
    
            SqlDataReader reader = command.ExecuteReader();
            DataTable schemaTable = reader.GetSchemaTable();
    
            foreach (DataRow row in schemaTable.Rows)
            {
                foreach (DataColumn column in schemaTable.Columns)
                {
                    Console.WriteLine(String.Format("{0} = {1}",
                       column.ColumnName, row[column]));
                }
            }
        }
    }
