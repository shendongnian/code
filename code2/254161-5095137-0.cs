    protected void gvProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
                Literal1.Visible = gvProduct.PageIndex == 0;
                m_newPageIndex = e.NewPageIndex;
                gvProduct.PageIndex = e.NewPageIndex;
                FillGrid();
    }
    
    protected void gvProduct_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager) {
          LinkButton lnkPrv = (LinkButton)e.Row.FindControl("lnkPrv");
          LinkButton lnkNext = (LinkButton)e.Row.FindControl("lnkNext");
          lnkPrv.Visible = m_newPageIndex > 0;
          lnkNext.Visible = m_newPageIndex < gvProduct.PageCount - 1;
         }
    }
