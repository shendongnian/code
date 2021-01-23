    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        CheckBox chk = (CheckBox)e.Row.FindControl("checkbox1");
        TextBox txt = (TextBox)e.Row.FindControl("quantity");
    
        chk.Attributes["onclick"] = string.Format("ChangeQuantityEnable('{0}', this.checked);", txt.ClientID);
    }
