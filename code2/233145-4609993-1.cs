    protected void MethodName(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
    if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
         DropDownList Hello = e.Row.FindControl("Hello") as DropDownList;
         //here you can bind the dropdown list.
        
        }
    }
