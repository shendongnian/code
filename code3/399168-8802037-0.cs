    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState != DataControlRowState.Edit)
        {
            if (e.Row.Cells[0].Text != "")
            {
                e.Row.Cells[0].ToolTip = e.Row.Cells[0].Text.Replace(Environment.NewLine, "<br/>");
                e.Row.Cells[0].Text = "";
                e.Row.Cells[0].BackColor = Color.Lavender;
            }
        }
    }
