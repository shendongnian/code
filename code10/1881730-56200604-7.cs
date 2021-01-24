    {
    int dorintaId = 0
    
    
    	 String CS = ConfigurationManager.ConnectionStrings["BudgetDBConnectionString1"].ConnectionString;
    	 using(SqlConnection con = new SqlConnection(CS)) {
    	  SqlCommand cmd = new SqlCommand("insert into Planuri values('" + tbNumeDorinta.Text + "','" + tbTarget.Text + "','" + tbPretE.Text + "'); ; SET @ID = SCOPE_IDENTITY();", con);
          cmd.Parameters.Add("@ID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
    	  con.Open();
    	  cmd.ExecuteNonQuery();
    	  
    	  dorintaId = (int) cmd.Parameters["@ID"].value;
    	 }
