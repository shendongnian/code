    protected void gvSorting_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtSortTable = gvSorting.DataSource as DataTable;
        if (dtSortTable != null)
        {
            DataView dvSortedView = new DataView(dtSortTable);
            dvSortedView.Sort = e.SortExpression + " " + getSortDirectionString(e.SortDirection);
            gvSorting.DataSource = dvSortedView;
            gvSorting.DataBind();
        }
    }
    private static string getSortDirectionString(SortDirection sortDireciton)
    {
        string newSortDirection = String.Empty;
        if (sortDireciton == SortDirection.Ascending)
        {
            newSortDirection = "ASC";
        }
        else
        {
            newSortDirection = "DESC";
        }
        return newSortDirection;
    }
