    void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var passed = (listView1.SelectedItems.Cast<ListViewItem>().Select(l => l.Group.Header).Distinct().Count() >= 2);
        if (passed)
        {
            //So something...
        }
    }
