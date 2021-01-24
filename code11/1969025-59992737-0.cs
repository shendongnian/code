    public void TeacherLogin()
    {
    	try
    	{
    		using(SqlConnection con = new SqlConnection("connection string");
    		{
    			using(SqlCommand cmd = new SqlCommand("TeacherLogin")
    			{
    				cmd.CommandType = CommandType.StoredProcedure;
    				cmd.Parameters.AddWithValue("@username", Txt_User.Text);
    				cmd.Parameters.AddWithValue("@password", Txt_Pass.Text);
    				cmd.Connection = con;
    				con.Open();
    				using(SqlDataReader dr = cmd.ExecuteReader())
    				{
    					while(dr.Read())
    					{
    						TeacherDash teacherDash = new TeacherDash();
    						this.Hide();
    						teacherDash.lblusertype.Text = dataReader[1] + " " + dataReader[2].ToString();
    						teacherDash.ShowDialog();
    					}
    				}
    			}
    		}
    	}
    	catch (Exception ex)
    	{
    		MessageBox.Show(ex.Message);
    	}
    }
