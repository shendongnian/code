    using (SqlConnection conn = new SqlConnection("Your connection string..."))
    {
        conn.Open();
    	foreach (var item in checkedComboBox1.Items)
	    {
		     using (SqlCommand cmd = new SqlCommand())
        	 {
		    	cmd.Connection = conn;
			    cmd.CommandText = $"UPDATE TableName SET [checked] = '{item.IsChecked}' WHERE [colour] = '{item.Text}'"
     			cmd.ExecuteNonQuery();
		     }
       	}
        conn.Close();
    }
