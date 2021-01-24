	private void Form1_Load(object sender, EventArgs e)
         {
	    
             con = new SqlConnection();
             con.ConnectionString= (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\New\RemDaBase.mdf;Integrated Security=True;Connect Timeout=30");
             con.Open();
             adapt = new SqlDataAdapter("SELECT * FROM  TB1", con);
	         DataTable dt = new DataTable();
	         BindingSource bs = new BindingSource();
	         bs.DataSource = dt;
             adapt.Fill(dt);
             dataGridView1.DataSource = dt;
         }
    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            cmdbl = new SqlCommandBuilder(adapt);
            adapt.Update(dt);
            MessageBox.Show("Updated Successfully");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
