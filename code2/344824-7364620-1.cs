    protected void MyGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox cbox = (CheckBox)e.Row.FindControl("chkBox");
    
            // Do some funky logic
            cbox.Visible = Event.HasRoom; //Boolean Propery
            // Or
            cbox.Visible = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "HasRoom").ToString());
    
        }
    }
