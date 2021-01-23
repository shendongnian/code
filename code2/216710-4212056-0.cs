    protected void Button2_Click(object sender, EventArgs e)
    {
    	String a = DropDownList1.SelectedItem.Value;
    	String b = DropDownList3.SelectedItem.Value.PadLeft(3, '0');      
    	String c = TextBox2.Text.PadLeft(5,'0').ToString();
    	String d = TextBox3.Text.ToString();
    	String digit = a+ b  + c + d;
    	string sql = "select * from testcase.main where reg_no =?";
    
    	try
    	{
    		using (OdbcConnection myConn = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};Server=localhost;Database=testcase;User=root;Password=root;Option=3;"))
    		using (OdbcCommand cmd = new OdbcCommand(sql, myConn))
    		{
    			myConn.Open();
    			//**
    			cmd.Parameters.AddWithValue("?", digit);
    			using (OdbcDataReader MyReader = cmd.ExecuteReader())
    			{
    				//**
    				while (MyReader.Read())
    				{
    					String f = MyReader["pet_name"].ToString();
    					String g = MyReader["res_name"].ToString();
    
    					Label9.Visible = true;
    					Label9.Text = f;
    
    					Label10.Visible = true;
    					Label10.Text = "VS";
    
    					//Label11.Visible = true;
    					Label11.Text = g;
    
    				}
    			}
    		}
    	}
    	catch (Exception e1)
    	{
    		Response.Write(e1.ToString());
    	}
    }
