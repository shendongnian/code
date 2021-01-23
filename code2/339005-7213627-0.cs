    protected void grdViewAttachment_Client_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {   
            LinkButton lnkbtnAttachments=(LinkButton)e.Row.FindControl("lnkbtnAttachments");       
            LinkButton.CommandArgument = e.Row.RowIndex.ToString();
            // similarly write for other controls
        }
    }
