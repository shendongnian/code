    // GridView1 Row DataBound event: adds selection functionality
	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		// Excludes row header and pager rows
		if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Pager)
		{
			e.Row.Attributes.Add("onmousedown", "IsMouseDown(this," + e.Row.RowIndex + ")");
			e.Row.Attributes.Add("onmouseup", "IsMouseDown(this," + e.Row.RowIndex + ")");
			e.Row.Attributes.Add("onmouseover", "HighlightRow(this," + e.Row.RowIndex + ")");
		}
	}
