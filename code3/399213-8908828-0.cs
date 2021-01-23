    command = new SqlCommand(query, con);     
     
    command.Parameters.AddWithValue("@NumberOfErrors", errors);//set a new error.     
    command.ExecuteNonQuery();     
    
    SqlCommand command = new SqlCommand(query2, con);//checks how much errors was in the last time played.     
     
    errors =(int)command.ExecuteScalar();     
    con.Close();     
