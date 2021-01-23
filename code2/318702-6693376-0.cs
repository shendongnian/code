    DataSet ds = new DataSet();
    
    using(SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConn"].ToString()))
    using(SqlCommand cmd = new SqlCommand("MYSP 'param1', param2, param3", conn))
    {  
        cmd.CommandType = CommandType.StoredProcedure;  <== STORED PROCEDURE !!
         ......
    }
