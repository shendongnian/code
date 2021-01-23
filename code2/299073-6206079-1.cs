     protected void MyGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Edit)
            {
                Label lbl = (Label)e.Row.FindControl("lblId");
    
            }
         
        }
