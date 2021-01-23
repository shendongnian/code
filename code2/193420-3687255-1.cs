    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow){
        var item = (DataRow)e.Row.DataItem;
        //I'm assuming the type is DataRow from you above example
        var linkCol = (HyperLinkField)e.Row.Cells[yourHyperLinkIndex] 
        linkCol.NavigateUrl = item["columnName"];
      }
    }
