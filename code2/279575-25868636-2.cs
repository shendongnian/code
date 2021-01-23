    protected void fvReport_ModeChanging(Object sender, FormViewModeEventArgs e)
    {
        
    }
    protected void lbEdit_Click(object sender, EventArgs e)
    {
        LinkButton lbEdit = (LinkButton)fvReport.FindControl("lbEdit");
        if (sender == lbEdit)
        {
            fvReport.DataBind();
            fvReport.ChangeMode(FormViewMode.Edit);
        }
    }
