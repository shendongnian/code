    protected void GdvDetails_RowDataBoundd(object sender, GridViewRowEventArgs e)
    {   
      if(e.Row.RowType == DataControlRowType.DataRow)
      { 
         CheckBox chkItem = (CheckBox)e.Row.FindControl("active");
         if (chkItem.Checked)
         {
             GdvDetails.SelectedRow.BackColor = Color.LightGray;
         }
      }
    }
