    protected void TaskGridView_Sorting(object sender, GridViewSortEventArgs e)
    {
		//Retrieve the table from the session object.
		DataTable dt = Session["TaskTable"] as DataTable;
		if (dt != null)
		{
			//Sort the data.
			dt.DefaultView.Sort = e.SortExpression;
			GridView1.DataSource = dt.DefaultView;
			GridView1.DataBind();
		}
	}
