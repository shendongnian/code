    GridView1.DataBind();
    if (GridView1.Columns.Count > 0)
        GridView1.Columns[0].Visible = false;
    else
    {
        GridView1.HeaderRow.Cells[0].Visible = false;
        foreach (GridViewRow gvr in GridView1.Rows)
        {
            gvr.Cells[0].Visible = false;
        }
    }
