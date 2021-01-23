    public bool CheckTableExistance(string TableName)
        {
            // Variable to return that defines if the table exists or not.
            bool TableExists = false;
            // Try the database logic
            try
            {
                // Make the Database Connection
                ConnectAt();
                // Get the datatable information
                DataTable dt = _cnn.GetSchema("Tables");
                // Loop throw the rows in the datatable
                foreach (DataRow row in dt.Rows)
                {
                    // If we have a table name match, make our return true
                    // and break the looop
                    if (row.ItemArray[2].ToString() == TableName)
                    {
                        TableExists = true;
                        break;
                    }
                }
                
                //close database connections!
                Disconnect();
                return TableExists;
            }
            catch (Exception e)
            {
                // Handle your ERRORS!
                return false;
            }
        }
