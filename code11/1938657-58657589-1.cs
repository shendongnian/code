    public void FillDataGridView()
    {
       cmd = new SqlCommand();
       cmd.CommandText = "Select * from AGENTS";
       cmd.Connection = Connection();
       adpt = new SqlDataAdapter(cmd);
       dt = new DataTable("AGENTS");
       adpt.Fill(dt);
       datGridView.ItemsSource = dt.DefaultView;
    }
