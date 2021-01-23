    protected void lv2_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "NewRecord")
        {
           ListView lv2 = (ListView)sender;
           lv2.InsertItemPosition = InsertItemPosition.FirstItem;
        }
    }
