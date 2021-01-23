    protected void RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState == DataControlRowState.Edit)
        {
            // Comments
            TextBox comments = (TextBox)e.Row.Cells[column_index].Controls[control_index];
            comments.TextMode = TextBoxMode.MultiLine;
            comments.Height = 100;
            comments.Width = 400;
        }
    }
