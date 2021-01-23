            string connectionstring = "Your connection string";
            string[] restrictionValues = new string[4]{null,null,null,"TABLE"};
            OleDbConnection oleDbCon = new OleDbConnection(connectionString);
            List<string> tableNames = new List<string>();
            try
            {
                oleDbCon.Open();
                DataTable schemaInformation = oleDbCon.GetSchema("Tables", restrictionValues);
                foreach (DataRow row in schemaInformation.Rows)
                {
                   tableNames.Add(row.ItemArray[2].ToString());
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                oleDbCon.Close();
            }           
