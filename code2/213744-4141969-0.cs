    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
    	GridViewRow row = e.Row;
    
    	if (row.RowType == DataControlRowType.DataRow) {
    		//A value to check for
    		string myValue = DataBinder.Eval(e.Row.DataItem, "myColumn").ToString();
    
    		if ((myValue == "a")) {
    			//Hide the row
    			row.Visible = false;
    		}
    	}
    }
