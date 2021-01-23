    ListViewItem item1 = new ListViewItem("item1",0);
    item1.SubItems.Add("1");
    item1.SubItems.Add("2");
    item1.SubItems.Add("3");
    ListViewItem item2 = new ListViewItem("item2",1);
    item2.SubItems.Add("4");
    item2.SubItems.Add("5");
    item2.SubItems.Add("6");
    listView1.Items.AddRange(new ListViewItem[]{item1,item2});
