    protected void GridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if(e.Row.RowType == DataControlRowType.DataRow)
      {
         var dropdownList = (DropDownList)e.Row.FindControl("ddlMyQuantity");
         for (int i = 1; i < 15; i++)
         {
            dropdownList.Items.Add(i.ToString());
         }
         dropdownList.SelectedValue = 
               Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Quantity"));
      }
    }
