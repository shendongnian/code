      Repeater repeater1=FormView1.FindControl("Repeater1")as Repeater;
    protected void RptrSupplier_ItemDataBound(Objectsender,System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if(e.Item.ItemType = ListItemType.Item || e.Item.ItemType = ListItemType.AlternatingItem)
        {
              TextBox t = e.Item.FindControl("TextBox1") as TextBox;
              t.ID = ((MyType)e.Item.DataItem).ID.ToString(); //you should cast to the type of your object
              t.TextChanged += txt1_TextChanged;
         }
    }
    protected void txt1_TextChanged(object sender, EventArgs e)
    {
        TextBox t = sender as TextBox;
        var tempobject = MyCollection.Where(C => C.ID == t.ID).Single();  
        tempobject.Prop = t.Text;
    }
