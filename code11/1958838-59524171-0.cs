    string ConnectionString;
    SqlConnection con;
    
    ConnectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = myDatabase; Integrated Security = True"; };
    
    private void button1_Click(object sender, EventArgs e)
    {
        con = new SqlConnection(ConnectionString);
        con.Open();
        SqlDataAdapter sdf = new SqlDataAdapter("SELECT * FROM CurrencyConversionAuditing", con);
        DataTable sd = new DataTable();
        sdf.Fill(sd);
        con.Close();
        dataGridView1.DataSource = sd;
    }    
