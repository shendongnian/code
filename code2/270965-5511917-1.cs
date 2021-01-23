    protected void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        System.Data.DataRowView dr = (System.Data.DataRowView)e.Row.DataItem;
            String x = dr["yourColumnName"].ToString();
            GridView gridView2 = (GridView)e.Row.Findcontrol("gridView2");//add this
            gridView2.DataSource = Assign Data source here;
            gridView2.DataBind();
    }
    }
