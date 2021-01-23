    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[1].Attributes.Add("class", "text");
            e.Row.Cells[2].Attributes.Add("class", "text");
        }
    }
