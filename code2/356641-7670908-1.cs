    SqlConnection cn = new SqlConnection(cnstr);
    SqlCommand cmd = new SqlCommand();
    cmd.Connection = cn;
    cmd.CommandText = "login_procedure";
    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    
    
    SqlParameter param1 = new SqlParameter("@username", System.Data.SqlDbType.VarChar, 50);
    SqlParameter param2 = new SqlParameter("@password", System.Data.SqlDbType.VarChar, 50);
    SqlParameter resultParam= new SqlParameter("@result", System.Data.SqlDbType.Int);
    resultParam.Direction = System.Data.ParameterDirection.Output;
    
    param1.Value = TextBox1.Text;
    param2.Value = TextBox2.Text;
    
    cmd.Parameters.Add(param1);
    cmd.Parameters.Add(param2);
    cmd.Parameters.Add(resultParam);
    
    cn.Open();
    cmd.ExecuteNonQuery();
    cn.Close();
    
    int retVal;
    int.TryParse(resultParam.Value.ToString(),out retVal);
    if(retVal==1)
      //
    else
      //
 
