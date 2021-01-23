    void ProductsGridView_RowCreated(Object sender, GridViewRowEventArgs e)
    {    
        var lbl = e.Row.FindControl("lblCheckPointCode");
        if(lbl != null) lbl.Visible = !IsPopup;
        var lnk= e.Row.FindControl("lbtnCheckPointCode");
        if(lnk!= null) lbl.Visible = !IsPopup;
    }
