    private void insertDataTable(DataTable MyDataTable)
            {
                string ConnectionString = "your connection string";
                using (SqlBulkCopy bulkcopy = new SqlBulkCopy(ConnectionString)
                {
                    bulkcopy.DestinationTableName = “dbo.<your table>”;
                    try
                    {
                        bulkcopy.WriteToServer(MyDataTable);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                  }
              }
