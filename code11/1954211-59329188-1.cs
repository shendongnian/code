    private void btnInsert_Click(object sender, EventArgs e)
    {
    	try
    	{
    		if (Validation())
    		{
    			if (IfUsernameExists(txtUsername.Text))
    			{
    				MessageBox.Show("Username already exists!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    			}
    			else
    			{
    				using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString))
    				{
    					conn.Open();
    					string sql = "INSERT INTO[Users](name, email, username, password, role, dob, address) VALUES(@Name, @Email, @username, @password, @role, @dob, @address)";
    					using (var cmd = new SqlCommand(sql, conn))
    					{
    						cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = txtName.Text;
    						cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = txtEmail.Text;
    						cmd.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = txtUsername.Text;
    						cmd.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = txtPassword.Text; //This really needs to be salted and hashed instead of plain text!!!!
    						cmd.Parameters.Add("@role", SqlDbType.VarChar, 50).Value = cbRole.Text;
    						cmd.Parameters.Add("@dob", SqlDbType.DateTime).Value = dtDob.Value;
    						cmd.Parameters.Add("@address", SqlDbType.VarChar, 50).Value = txtAddress.Text;
    						cmd.ExecuteNonQuery();
    					}
    				}
    				MessageBox.Show("Record Saved Succesfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
    				Clear_Data();
    				LoadData();
    			}
    		}
    	}
    	catch(Exception ex)
    	{
    		//Log the error here so you have a record of it.
    		//Maybe even send an email that something failed
    		MessageBox.Show(ex.ToString(), "An error occurred.", MessageBoxButtons.OK, MessageBoxIcon.Error);
    	}
    }
