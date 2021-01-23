    protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
    { 
      if(r.Row.RowType == DataControlRowType.DataRow)
      {
        DropDownList dropdown = e.Row.FindControl("DropDown") as DropDownList;
        if(dropdown != null)
        { /*  your code */ }
      }
    }
