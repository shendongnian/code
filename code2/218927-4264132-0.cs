    string type = DropDownList3.Items[DropDownList3.SelectedIndex].Text;
    string commandText = "select casename,skey from casetype where skey=@key;";
    using (SqlConnection connection = new SqlConnection("Server=localhost;Database=testcase;Integrated Security=SSPI"))
    {
    	SqlCommand command = new SqlCommand(commandText, connection);
    	command.Parameters.Add("@key", SqlDbType.String);
    	command.Parameters["@key"].Value = customerID;
    	//command.Parameters.AddWithValue("@key", type);
    	
    	try
    	{
    		connection.Open();
    		Int32 rowsAffected = command.ExecuteNonQuery();
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine(ex.Message);
    	}
    
    }
