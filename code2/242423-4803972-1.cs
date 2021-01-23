protected void Page_Load(object sender, EventArgs e)
{
    gvTest.DataSource = new[] { 1, 2, 3, 4 };
    gvTest.DataBind();
}
protected void gvTest_RowDataBound(object sender, GridViewRowEventArgs e)
{
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        int item = (int)e.Row.DataItem;
        Label lblTest = (Label)e.Row.FindControl("lblTest");
        lblTest.Text = item.ToString();
    }
}
