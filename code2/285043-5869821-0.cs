    SqlConnection cs = new SqlConnection("Data Source=IRIS-CSG-174;Initial Catalog=library_system;Integrated Security=True"); 
            cs.Open();
    SqlCommand cmd = new SqlCommand("select * from dbo.lib_issue_details where CAST(book_issue_on AS Date) between CAST(@StartDate AS Date) and CAST(@EndDate AS Date)", cs);
    cmd.Parameters.Add(new SqlParameter("@StartDate", dateTimePicker1.Text)); //If this is a datetimepicker it would be better to use: dateTimePicker1.Value
    cmd.Parameters.Add(new SqlParameter("@EndDate", dateTimePicker1.Text)); //If this is a datetimepicker it would be better to use: dateTimePicker1.Value
    SqlDataAdapter da = new SqlDataAdapter(cmd); 
    DataTable dt = new DataTable(); DataSet ds = new DataSet(); 
    da.Fill(ds, "lib_issue_details"); 
    dataGridView1.DataSource = ds.Tables[0]; 
    
    //By Default it will infer the columns from your dataset, otherwise create the columns on your designer
    //dataGridView1.DataBindings.Add(new Binding("text", ds, "lib_issue_details"));
    cs.Close();
