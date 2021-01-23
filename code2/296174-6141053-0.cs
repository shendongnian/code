    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        DataRow dr = ((DataRowView)e.Row.DataItem).Row;
        if(dr["ColumnName"] && dr["ColumnName1"])
        {
          e.Row.Style.Add("Color", "Red");         
        }
      }
    }
