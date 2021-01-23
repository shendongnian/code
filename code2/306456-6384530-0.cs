    DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
    
    using (DbConnection connection = factory.CreateConnection())
    {
        connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\MyExcel.xls;Extended Properties="Excel 8.0;HDR=Yes;IMEX=1";
        connection.Open();
    
        using (DbCommand command = connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM [Sheet1$]";
    
            using (DbDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    /* read data here */
                }
            }
        }
    }
