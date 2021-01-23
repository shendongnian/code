    protected void ListView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        using (ListViewDataItem listViewDataItem = (ListViewDataItem) e.Item)
        {
            if (listViewDataItem != null)
            {
                Label monkeyLabel = (Label)e.Item.FindControl("monkeyLabel");
                bool linkable = (bool)DataBinder.Eval(listViewDataItem , "IsLinkable");
                if (linkable)
                   monkeyLabel.Text = "monkeys!!!!!! (please be aware there will be no monkeys, this is only for humour purposes)";
            }
        }
    }
