    protected void grdList1_Sorting(object sender, GridViewSortEventArgs e)
    {
            fillgrid();
            string sortstr = e.SortExpression;
            DataView dview = new DataView(dtable);
            if (sortstr == "asc")
                dview.Sort = e.SortExpression + " desc";
            else
                dview.Sort = e.SortExpression + " asc";
            grdList1.DataSource = dview;
            grdList1.DataBind();
    }
