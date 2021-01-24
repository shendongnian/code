    select.Parameters.Add("@taughtOn", SqlDbType.VarChar, 50).Value = taughtOn; 
    string cmd = @"select ID, Name from " + attackCategory + " where TaughtOn =@taughtOn"; 
    select.CommandText = cmd; 
    select.Connection = new SqlConnection("provide your sql string");
    using (SqlDataAdapter sda = new SqlDataAdapter(select)) 
    { 
    DataTable dt = new DataTable(); 
    sda.Fill(dt); 
    return dt; 
    }
