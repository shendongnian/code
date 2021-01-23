      Repeater repeater1=FormView1.FindControl("Repeater1")as Repeater;
    protected void RptrSupplier_ItemDataBound(Objectsender,System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if(e.Item.ItemType = ListItemType.Item || e.Item.ItemType = ListItemType.AlternatingItem)
        {
              TextBox t = e.Item.FindControl("TextBox1") as TextBox;
              t.TextChanged += txt1_TextChanged;
         }
    }
    protected void txt1_TextChanged(object sender, EventArgs e)
    {
        TextBox t = sender as TextBox;
        Response.Write(t.Text);
    }
