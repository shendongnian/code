    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e){
    GridView1.DataSource = SortDataTable(GetYourDataSource(), true);
    GridView1.PageIndex = e.NewPageIndex;
    GridView1.DataBind();}private string GridViewSortDirection{
    get { return ViewState["SortDirection"] as string ?? "ASC"; }
    set { ViewState["SortDirection"] = value; }}private string GridViewSortExpression{
    get { return ViewState["SortExpression"] as string ?? string.Empty; }
    set { ViewState["SortExpression"] = value; }}private string ToggleSortDirection(){
    switch (GridViewSortDirection)   {
      case "ASC":
            GridViewSortDirection = "DESC";
          break;
      case "DESC":
            GridViewSortDirection = "ASC";
          break;   }
    return GridViewSortDirection;}protected DataView SortDataTable(DataTable dataTable, bool isPageIndexChanging){
    if (dataTable != null)   {
        DataView dataView = new DataView(dataTable);
        if (GridViewSortExpression != string.Empty)
       {
            if (isPageIndexChanging)
           {
                dataView.Sort = string.Format("{0} {1}",  GridViewSortExpression,GridViewSortDirection);
           }
           else
           {
                dataView.Sort = string.Format("{0} {1}",  GridViewSortExpression,ToggleSortDirection());
           }
       }
    return dataView;   }   else   {
        return new DataView();   }}protected void GridView1_Sorting(object sender, GridViewSortEventArgs e){
    GridViewSortExpression = e.SortExpression;
    int pageIndex = GridView1.PageIndex;
    GridView1.DataSource = SortDataTable(GetYourDataSource(), false);
    GridView1.PageIndex = pageIndex;
    GridView1.DataBind();}
