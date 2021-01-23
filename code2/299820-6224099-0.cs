    void gvAppRejProfiles_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label bl = 
             (Label)e.Row.FindControl("lbtnResumes");
         
            
        }
    }
