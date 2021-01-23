    protected void AttribGrid_RowEditing(object sender, GridViewEditEventArgs e)
    	{
    		AttribGrid.EditIndex = e.NewEditIndex;
    		AttribGrid.DataSource = (DataSet)ViewState["CurTable"];
    		AttribGrid.DataBind();
    		
    	}
