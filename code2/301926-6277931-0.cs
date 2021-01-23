    void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var firstCell = e.Row.Cells[0];
            firstCell.Controls.Clear();
            firstCell.Controls.Add(new HyperLink { NavigateUrl = firstCell.Text, Text = firstCell.Text });
        }
    }
