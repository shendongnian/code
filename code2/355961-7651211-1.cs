    protected void Ds_my_projects_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[1].Text.ToString().Length > 200)
            {
                e.Row.Cells[1].Text = e.Row.Cells[1].Text.ToString().Substring(0, 200) + "...";
            }
        }
    }
