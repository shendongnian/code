    public dynamic GetAll(string propName)
    {
    
        using (var context = new SampleContext())
        using (var command = context.Database.GetDbConnection().CreateCommand())
        {
            //Escape propName to prevent SQL injection
            var builder = new SqlCommandBuilder();
            string escapedTableName = builder.QuoteIdentifier(propName);
            command.CommandText = $"SELECT * From {escapedTableName}";
            context.Database.OpenConnection();
            using (var dataReader= command.ExecuteReader())
            {
               var dataTable = new DataTable();
               dataTable.Load(dataReader);
               return dataTable ;
            }
        }
    }
