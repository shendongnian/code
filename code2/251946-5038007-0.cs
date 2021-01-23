    private void BindGrid(GridView grid)
    {
      using(SqlConnection cn = new SqlConnection("Some Connection string"))
      using(SqlCommand cmd = new SqlCommand("Select * from Person", cn))
      {
        cmd.CommandType = CommandType.Text;
        cmd.Connection.Open();
        using(SqlDataAdapter da = new SqlDataAdapter(cmd))
        {
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            grid.DataBind();
        }
      }
    }
