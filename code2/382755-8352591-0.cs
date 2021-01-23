    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow)
       {
         DropDownList dropDown;
         dropDown= e.Row.FindControl("ddlDefState") as DropDownList;
          if (dropDown!= null)
            // Write your code here            
        }
    }
