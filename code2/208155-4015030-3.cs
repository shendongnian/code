    protected void gv_FilesList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
    	if (e.CommandName == "DownloadFile")
    	{
    		//row index
    		int index = Convert.ToInt32(e.CommandArgument);
    		//retrieve f_Id    
    		int f_Id = Convert.ToInt32(gv_FilesList.DataKeys[index].Value);
    		
    		//download file with f_Id
    		DownloadFile(f_Id);
    	}
    }
