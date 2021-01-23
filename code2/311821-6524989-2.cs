    SqlConnection cn = new SqlConnection(<connection string to yer database>);
    SqlCommand cm = new SqlCommand("exec sp_databases", cn);
    SqlDataAdapter sda = new SqlDataAdapter();
    DataSet ds = new DataSet();
    sda.SelectCommand = cm;
    sda.Fill(ds, "db");
    for (int i = 0; i < ds.Tables["db"].Rows.Count; i++)
    {
        comboBox1.Items.Add(ds.Tables["db"].Rows[i]["DATABASE_NAME"].ToString());
    }
