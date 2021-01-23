    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      CheckBox c = e.Row.Cells[4].FindControl("YourCheckboxId");
      if(c != null && e.Row.DataItem["sFixed_f"] == true)
      {
        c.Checked = true;
      }
    }
