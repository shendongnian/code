    protected void gvMain_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        FunctionCollection objTempFuncColl = (FunctionCollection)Cache["objFuncColl"];
        Repeater rt = (Repeater)e.Row.FindControl("rtFunctions");
        if (e.Row.RowType == DataControlRowType.DataRow && objTempFuncColl.Count !=0 )
        {
            rt.DataSource = objTempFuncColl;
            rt.DataBind();
        }
    }
    
    protected void rtFunctions_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        lnk.Text = ((Functions)e.Item.DataItem).funcName;
    }
