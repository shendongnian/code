    var table = new DataTable(); 
    
    using(SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; AttachDbFileName=|DataDirectory|database.mdf;"))
    using(SqlCommand command =  new SqlCommand($"SELECT name FROM database WHERE age = 25", con))
    using(SqlDataAdapter adapter = new SqlDataAdapter(command))
    {
    	con.Open();
    	adapter.Fill(table);
    }
    
    
    // if single row 
    if (table.Rows[0].Field<string>("name") != textbox.Text)
    {
     //do something
    }
    
    //if multiple rows 
    for(int x = 0; x < table.Rows.Count; x++)
    {
    	if (table.Rows[x].Field<string>("name") !=  textbox.Text)
    	{
    	 //do something
    	}
    }
