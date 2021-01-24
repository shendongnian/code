    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        //...
        var p = listView1.PointToClient(Cursor.Position);
        if (e.Item.GetBounds(ItemBoundsPortion.Entire).Contains(p))
        {
            //e.Item is Hot
        }
        else
        {
            //e.Item is Normal
        }
        //...
    }
