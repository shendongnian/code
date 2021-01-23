    private string m_ConcatUrl;
    protected void gridView_RowDataBound(Object sender, GridViewRowEventArgs args)
    {
        if(args.Row.RowType == DataControlRowType.DataRow)
        {
            Image imgCtrl = (Image) args.Row.FindControl("imgCtrl");
            imgCtrl.ImageUrl = m_ConcatUrl;
        }
    }
