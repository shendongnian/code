    protected void mygridview_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
    	if (e.CommandName == "Add") {
    		var txtFName1 = (TextBox)((GridView)sender).FooterRow.FindControl("txtFName1");
    	}
    }
