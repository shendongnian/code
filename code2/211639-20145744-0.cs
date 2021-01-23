    protected void Page_Load(object sender, EventArgs e)
    {
      grid.RowDataBound += grid_RowDataBound;
      // Your DB access code here...
      // grid.DataSource = cmd.ExecuteReader(CommandBehavior.CloseConnection);
      // grid.DataBind();
    }
    
    void grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;
      var dt = (e.Row.DataItem as DbDataRecord).GetDateTime(4);
      e.Row.Cells[4].Text = dt.ToString("dd.MM.yyyy");
    }
