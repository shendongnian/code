     protected void Button1_Click(object sender, EventArgs e)
        {
        SqlConnection myConnection = new SqlConnection("Data Source=localhost;Initial Catalog=Northwind;uid=sa;pwd=sa;");
        myConnection.Open();
        
        // Start a local transaction
        SqlTransaction myTrans = myConnection.BeginTransaction();
        
        SqlCommand myCommand = new SqlCommand();
        myCommand.Connection = myConnection;
        myCommand.Transaction = myTrans;
        try
        {
        myCommand.CommandText = "Insert into Region (RegionID, RegionDescription) VALUES (100, 'Description')";
        myCommand.ExecuteNonQuery();
        myCommand.CommandText = "delete * from Region where RegionID=101";
        
        // Attempt to commit the transaction. 
        myCommand.ExecuteNonQuery();
        myTrans.Commit();
        Response.Write("Both records are written to database.");
        }
        catch (Exception ep)
        {
        // Attempt to roll back the transaction. 
        myTrans.Rollback();
        Response.Write(ep.ToString());
        Response.Write("Neither record was written to database.");
        }
        finally
        {
        myConnection.Close();
        }
        }
