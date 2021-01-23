    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow 
            && (e.Row.RowState == DataControlRowState.Normal 
                || e.Row.RowState == DataControlRowState.Alternate))
        {
            LinkButton Btn1 = e.Row.FindControl("Btn1 ") as LinkButton; 
            ScriptManager.GetCurrent(this.Parent.Page).RegisterAsyncPostBackControl(Btn1 );
        }
        if (e.Row.RowType == DataControlRowType.DataRow 
            && e.Row.RowState == DataControlRowState.Edit)
        {
            LinkButton Btn2 = e.Row.FindControl("Btn2 ") as LinkButton;
            ScriptManager.GetCurrent(this.Parent.Page).RegisterAsyncPostBackControl(Btn2 );      
        }
    }
