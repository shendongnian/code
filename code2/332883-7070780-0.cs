    protected void Page_Load(object sender, EventArgs e)
    {
        grvbillDetail.RowDataBound += grvbillDetail_RowDataBound;
    }
    
    void grvbillDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow)
            return;
        var ddl = e.Row.FindControl("ddlCalculateGrid") as DropDownList;
        if (ddl != null)
        {
            ddl.DataSource = rcta.GetDataByTrueValue();
            ddl.DataBind();
        }
    }
    }
