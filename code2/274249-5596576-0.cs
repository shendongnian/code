    protected void ListView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Label monkeyLabel = (Label)e.Item.FindControl("monkeyLabel");
            bool linkable = (bool)DataBinder.Eval(e.Item.DataItem, "IsLinkable");
            if (linkable)
               monkeyLabel.Text = "monkeys!!!!!! (please be aware there will be no monkeys, this is only for humour purposes)";
        }
    }
