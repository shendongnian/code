    using (System.Data.SqlClient.SqlConnection con = new SqlConnection("YourConnection string")) { 
        con.Open(); 
        SqlCommand cmd = new SqlCommand(); 
        string expression = "(newsequentiali'd())"; 
        cmd.CommandType = CommandType.StoredProcedure; 
        cmd.CommandText = "Your Stored Procedure"; 
        cmd.Parameters.Add("Your Parameter Name", 
                    SqlDbType.VarChar).Value = expression;    
        cmd.Connection = con; 
        using (IDataReader dr = cmd.ExecuteReader()) 
        { 
            if (dr.Read()) 
            { 
            } 
        } 
    }
