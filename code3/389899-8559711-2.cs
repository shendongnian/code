    void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if(e.Row.RowType == DataControlRowType.DataRow)
      {
        var thisRow = (DataRowView)e.Row.DataItem;
        var source = thisRow.DataView;
        var lastRowIndex = e.Row.DataItemIndex -1;
        DataRowView lastRow = null;
        var ddl = (DropDownList)e.Item.FindControl("ddl");
        DropDownList ddlLast = null;
        if(lastRowIndex>=0){
            lastRow = source[lastRowIndex];
            ddlLast = (DropDownList)((GridView)sender).Rows[lastRowIndex].FindControl("ddl");
            //remove the items of this ddl according to the items of the last dll
        }
      }
    }
