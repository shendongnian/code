    string sql = "select * from customer where name like '" + textBox2.Text + "%'";
    string sql2 = "select * from customer";
    
    if (textBox2.Text.Length > 0)
    {
    	DataTable dt = CarDatabase.executeSelect(sql);
    	DataTable dt2 = CarDatabase.executeSelect(sql2);
    
    	if (dt == null)
    	{
    		dataGridView2.DataSource = dt2;
    		dataGridView2.DataBind();
    		MessageBox.Show("There's no result with " + textBox2.Text);
    	}
    	else if (dt != null)
    	{
    		dataGridView2.DataSource = dt;
    		dataGridView2.DataBind();
    	}
    }
    else
    {
    	MessageBox.Show("Please fill the textbox");
    }
