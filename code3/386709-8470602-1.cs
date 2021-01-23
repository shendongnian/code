    public void yourGridview_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // do your stuffs here, for example if column risk is your third column:
            if (e.Row.Cells[2].Text == 'high')
            {
                e.Row.BackColor = Color.Red;
            }
        }
    }
