    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
{
    GridView1.DataSource = SortDataTable(GetYourDataSource(), true);
    GridView1.PageIndex = e.NewPageIndex;
    GridView1.DataBind();
