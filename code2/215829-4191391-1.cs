     //row created
        protected void grvMergeHeader_RowCreated
        (object sender, GridViewRowEventArgs e)
        {
        if (e.Row.RowType == DataControlRowType.Header)
        {
        GridView HeaderGrid = (GridView)sender;
        GridViewRow HeaderGridRow =
        new GridViewRow(0, 0, DataControlRowType.Header,
        DataControlRowState.Insert);  //creating new Header Type 
        TableCell HeaderCell = new TableCell(); //creating HeaderCell
        HeaderCell.Text = "Department";
        HeaderCell.ColumnSpan = 2;
        HeaderGridRow.Cells.Add(HeaderCell);//Adding HeaderCell to header.
        
        HeaderCell = new TableCell();
        HeaderCell.Text = "Employee";
        HeaderCell.ColumnSpan = 2;
        HeaderGridRow.Cells.Add(HeaderCell);
        
        grvMergeHeader.Controls[0].Controls.AddAt
        (0, HeaderGridRow);
        
        }
        }
