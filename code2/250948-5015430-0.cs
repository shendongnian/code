    protected void myRepeater_ItemDataBound(object source, RepeaterCommandEventArgs e) {   
        if(e.Item.ItemType == ListItemType.Item){
           Panel pnl = (Panel)e.Item.FindControl("myPanel");   
           pnl.Attributes.Add"onMouseOver", "yourFnctionName()");
        }
    }
