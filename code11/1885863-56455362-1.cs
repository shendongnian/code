    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check if the row is a normal datarow
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //cast the row back to a datarowview
            DataRowView row = e.Row.DataItem as DataRowView;
            //use findcontrol to locate the nested gridview
            GridView gv = e.Row.FindControl("NestedGrid") as GridView;
            //bind data to the nested grid
            gv.DataSource = source;
            gv.DataBind();
            //set the column span to 3 on the cell that has the nested gridview
            e.Row.Cells[2].ColumnSpan = 3;
            //hide the last 2 cells
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[4].Visible = false;
        }
    }
