    protected void FormView1_DataBound(object sender, System.EventArgs e)
    {
    	switch (FormView1.CurrentMode) {
    		case FormViewMode.Insert:
    			var mygridview = (GridView)((FormView)sender).FindControl("mygridview");
                //Bind your GridView here'
    			break;
    	}
    }
