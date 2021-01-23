    protected void GridView1_RowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow) {
    		e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
    		e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
    		e.Row.ToolTip = "Click to select row";
    		e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
    	}
    }
