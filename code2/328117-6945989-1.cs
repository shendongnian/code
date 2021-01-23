    protected void GridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
         if(e.Row.RowType == DataControlRowType.DataRow)
         {
              int ItemId = Int32.Parse(YourGridView.DataKeys[e.Row.RowIndex].Values[0].ToString());
         }
    }
