    //Stored Procedure name is ADDCustomer_sp
    SqlCommand cmd = new SqlCommand("ADDCustomer_sp", con);
    
    cmd.CommandType = CommandType.StoredProcedure;
    
    SqlParameter Name = new SqlParameter("@CusName", SqlDbType.NVarChar, 50);
    Name.Value = TextBox1.Text;
    Name.Direction = ParameterDirection.Input;
    cmd.Parameters.Add(Name);
    
    cmd.ExecuteNonQuery();
