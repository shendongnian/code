	protected void gvData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                TextBox txtBox = e.Row.Cells[i].Controls[0] as TextBox;
		txtBox.TextMode = TextBoxMode.MultiLine;
            }
        }
    }
