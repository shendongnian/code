    private void button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=SUBASH-LAPTOP\COBRA;Initial Catalog=Test;Integrated Security=True");
        SqlCommand Command = con.CreateCommand();
        SqlDataAdapter dp = new SqlDataAdapter("Select * From orders where date_purchased <= @varDate", con);
        dp.SelectCommand.Parameters.AddWithValue("@varDate", dateTimePicker1.Value);
        DataSet ds = new DataSet();
        dp.Fill(ds);
        DataGridView d1 = new DataGridView();
        d1.DataSource = ds;
        d1.DataMember = ds.Tables[0].TableName;
        this.Controls.Add(d1);
    }    
