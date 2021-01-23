      Repeater repeater1=FormView1.FindControl("Repeater1")as Repeater;
     protected void RptrSupplier_ItemDataBound(Objectsender,System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if(e.Item.ItemType = ListItemType.Item || e.Item.ItemType = ListItemType.AlternatingItem)
        {
            
              TextBox t = e.Item.FindControl("TextBox1") as TextBox;
         }
    }
