    private string m_ConcatUrl;
    protected void gridView_RowDataBound(Object sender, GridViewRowEventArgs args)
    {
        if(args.Row.RowType == DataControlRowType.DataRow)
        {
            Image imgCtrl = (Image) e.Row.FindControl("imgCtrl");
            imgCtrl.ImageUrl = m_ConcatUrl;
        }
    }
