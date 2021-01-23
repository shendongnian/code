protected void uxListAuthorsDisplayer_RowCreated(object sender, GridViewRowEventArgs e)
{
    // Skip the header and footer rows
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        Label myLabel = (Label) e.Row.FindControl("uxUserIdDisplayer");
    }
}
