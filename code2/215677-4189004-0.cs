    protected void myGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            RadioButtonList rdoAnswer = (RadioButtonList)e.Row.FindControl("myRadio");
            HiddenField hdnValue = (HiddenField)e.Row.FindControl("myHidden");
                    
            rdoAnswer.SelectedValue = hdnValue.Value;
        }
    }
