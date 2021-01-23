    protected void gdvMainList_Sorting(object sender, System.Web.UI.WebControls.GridViewSortEventArgs e)
    {
        //Using DataView for sorting DataTable's data
        DataView view = dtMedication.DefaultView;
        view.Sort = String.Format("{0} {1}", e.SortExpression, GetSortingDirection());
        gdvMainList.DataSource = view;
        gdvMainList.DataBind();
    }
