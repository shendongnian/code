    void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedItems = listView1.SelectedItems.Cast<ListViewItem>();
        var passed = (selectedItems.Select(l => l.Group.Name).Distinct().Count() == 2 && selectedItems.Count() == 2);
        if (passed)
        {
             //Do something...
        }
    }
