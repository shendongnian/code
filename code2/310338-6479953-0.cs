    using(var cn = new SqlConnection("-my-connection-string-"))
    {
        SqlCommand cmd = new SqlCommand(cn, this.txtSqlCommand.Text);  
        using(SqlDataReader dr = cmd.ExecuteReader())
        {
              while(dr.Read())
              {
                     ...
              }
        }
    }
