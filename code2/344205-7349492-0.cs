    string excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Server.MapPath("ImportFile.xls") + ";"; 
        using (OleDbConnection connection = new OleDbConnection(excelConnectionString))
        {
            OleDbCommand command = new OleDbCommand("Select * FROM [NameOfTheDataSheet$]", connection);
            connection.Open();
            using (DbDataReader dataReader = command.ExecuteReader())
            {
                string sqlConnectionString = "SQL Connection String"; 
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnectionString))
                {
                    bulkCopy.DestinationTableName = "ExcelDataTable";
                    bulkCopy.WriteToServer(dataReader);
                }
            }
        }
