    protected void gvTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    	try
    	{
    
    		if (e.Row.RowType == DataControlRowType.EmptyDataRow)
    		{
    			LinkButton btn = (LinkButton)e.Row.FindControl("btnAgregarVacio");
    			if (btn != null)
    			{
    				btn.Visible = rbFiltroEstatusCampus.SelectedValue == "1" ? true : false;
    			}
    		}
    	}
    	catch (Exception ex)
    	{
    		throw ex;
    	}
    }
