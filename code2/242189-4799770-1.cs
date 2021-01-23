    void queryButton_Click(object sender, EventArgs e)
    {
    	TextBox querybox = this.FindControl("querybox") as TextBox;
    	try
    	{
    		 string query = querybox.Text;
    		 DataGrid dataGrid = new DataGrid();
    		 dataGrid.DataSource = Camelot.SharePointConnector.Data.Helper.ExecuteDataTable(query, connectionString);
    		 dataGrid.DataBind();
    		 Controls.Add(dataGrid);
    	}
    	catch (Exception a)
    	{
    		 Controls.Add(new LiteralControl(a.Message));
    	} // try
    }
