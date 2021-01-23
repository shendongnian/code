    using (SqlConnection con = new SqlConnection(connStr))
    {
        con.Open();
        // Create a table with some rows. 
        DataTable table = MakeTable();
        // Get a reference to a single row in the table. 
        DataRow[] rowArray = table.Select();
        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con))
        {
            bulkCopy.DestinationTableName = "dbo.CarlosBulkTestTable";
            try
            {
                // Write the array of rows to the destination.
                bulkCopy.WriteToServer(rowArray);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }//using
