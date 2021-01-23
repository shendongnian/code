    //First create a connection string to destination database
    string connectionString;
    connectionString = <EM>YourConnectionString</EM>and
    	Initial Catalog=TestSMODatabase";
    
    //Open a connection with destination database;
    using (SqlConnection connection = 
           new SqlConnection(connectionString))
    {
       connection.Open();
    
       //Open bulkcopy connection.
       using (SqlBulkCopy bulkcopy = new SqlBulkCopy(connection))
       {
       	//Set destination table name
    	//to table previously created.
    	bulkcopy.DestinationTableName = "dbo.TestTable";
    
    	try
    	{
    	   bulkcopy.WriteToServer(SourceTable); // SourceTable would come from your DataSet
    	}
    	catch (Exception ex)
    	{
    	   Console.WriteLine(ex.Message);
    	}
    	
    	connection.Close();
       }
    }
