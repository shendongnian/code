        try   
                 oleconnStkNames = new OleDbConnection(strAccessConnectionString);
                    oleconnStkNames.Open();                
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = oleconnStkNames; //new OleDbConnection(strAccessConnectionString);
                    cmd.CommandText = "TheName of your InsertQuery "; // name of the query you want to run
                    cmd.CommandType = CommandType.StoredProcedure; // or System.Data.CommandType.Text if you are not using a Access StoredProc
                    OleDbDataReader rdr = cmd.ExecuteReader();
        catch (Exception ex)
        {
        bla..bla..bla 
    
    }
