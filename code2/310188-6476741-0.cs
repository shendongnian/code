      OdbcDataReader DR = cmd.ExecuteReader();
     
    if (DR.Read() && DR.GetValue(0) != DBNull.Value)    
     {   
        args.IsValid = false; 
     } 
     else {   
     args.IsValid = true; } DbConnection.Close();
