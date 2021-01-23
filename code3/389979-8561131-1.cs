            Using (SqlConnection myCon = new SqlConnection('ConnectionString'))
            {
              myCon.Open();
              var transaction = myCon.BeginTransaction();    
              try 
              { 
                myCon.Open(); 
                // ... do some DB stuff - build your command with SqlCommand but use your transaction and your connection
               var sqlCommand = new SqlCommand(CommandString, myCon, transaction);
               sqlCommand.Parameters.Add(new Parameter()); // Build up your params
               sqlCommand.ExecuteNonReader(); // Or whatever type of execution is best
               transaction.Commit();  // Yayy!
            } 
            catch (Exception ex) 
            { 
                transaction.RollBack();  // D'oh!
                // ... Some logging
            } 
            
            myCon.Close();
        }
    
