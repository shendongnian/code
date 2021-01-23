    protected void GridView1_RowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.Footer) {
    		var grid = (GridView)sender;
    		Label lbl1 = new Label();
    		Label lbl2 = new Label();
    		TableCell footerCell = new TableCell();
    		TableCell cell1 = new TableCell();
    		TableCell cell2 = new TableCell();
    		TableRow footerRow = new TableRow();
    		Table footerTable = new Table();
    		e.Row.Cells.Clear();
    		footerCell.Controls.Add(footerTable);
    		footerTable.Rows.Add(footerRow);
    		lbl1.ID = "lbl1";
    		lbl2.ID = "lbl2";
    		cell1.Controls.Add(lbl1);
    		cell2.Controls.Add(lbl2);
    		footerRow.Cells.Add(cell1);
    		footerRow.Cells.Add(cell2);
    		e.Row.Cells.Add(footerCell);
    	}
    }
    
    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.Footer) {
    		DataRow row = getFooterSource().Rows[0];
    		var lbl1 = (Label)e.Row.FindControl("lbl1");
    		var lbl2 = (Label)e.Row.FindControl("lbl2");
    		lbl1.Text = row["Col1"];
    		lbl2.Text = row["Col2"];
    		e.Row.Cells[0].ColumnSpan = ((DataTable)((GridView)sender).DataSource).Columns.Count;
    	}
    }
    
    //get some mock-data
    private DataTable getFooterSource()
    {
    	DataTable tblFooter = new DataTable("Footer");
    	tblFooter.Columns.Add(new DataColumn("Col1", typeof(string)));
    	tblFooter.Columns.Add(new DataColumn("Col2", typeof(string)));
    	var footerRow = tblFooter.NewRow();
    	footerRow(0) = "first column's value";
    	footerRow(1) = "second column's value";
    	tblFooter.Rows.Add(footerRow);
    	return tblFooter;
    }
