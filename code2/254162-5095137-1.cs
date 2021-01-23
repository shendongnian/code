    protected void gvProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
                Literal1.Visible = gvProduct.PageIndex == 0;
                gvProduct.PageIndex = e.NewPageIndex;
                FillGrid();
    }
    
    protected void gvProduct_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Pager) {
          LinkButton lnkPrv = (LinkButton)e.Row.FindControl("lnkPrv");
          LinkButton lnkNext = (LinkButton)e.Row.FindControl("lnkNext");
          lnkPrv.Visible = gvProduct.PageIndex > 0;
          lnkNext.Visible = gvProduct.PageIndex < gvProduct.PageCount - 1;
         }
    }
