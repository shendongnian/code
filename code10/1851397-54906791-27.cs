    private void BindGrid()
    {
    
          string query = "SELECT * FROM approved WHERE tm = @tm";
          gdvTM.DataSource = GetDataTable(query);
          gdvTM.DataBind();
          this.BindDropDownList();
    }
    private DataTable GetDataTable(string query)
    {
          String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;
          using (MySqlConnection con = new MySqlConnection(strConnString))
          {
               using (MySqlCommand cmd = new MySqlCommand(query))
               {
                   using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                   {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tm", username.Text);
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
