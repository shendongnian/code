    public void TeacherLogin()
    {
    	try
    	{
    		using(SqlConnection con = new SqlConnection("connection string"))
    		{
    			using(SqlCommand cmd = new SqlCommand("TeacherLogin"))
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
    						teacherDash.lblusertype.Text = string.Format("{0} {1}", dr[1], dr[2]);
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
