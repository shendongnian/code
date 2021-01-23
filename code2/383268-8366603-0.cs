    void GridView_RowDataBound(Object sender, GridViewRowEventArgs e) 
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header ) {
            MyClass myObj = (myObj)e.Row.DataItem;
            CheckBox cb = (CheckBox)e.Row.FindControl("myCheckBox");
            cb.Enabled=false;        
        }
    }
