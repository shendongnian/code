        protected void gvAddresses_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
    	//Get the address Id to delete the selected address only
    	Label selectedAddessId = gvAddresses.Rows(e.RowIndex).FindControl("Label13");
    	SqlDataSource.DeleteParameters("add_id").DefaultValue = selectedAddessId.Text;
    	SqlDataSource.Delete();
    }
