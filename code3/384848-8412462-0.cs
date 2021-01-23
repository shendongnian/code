    ListViewItem item;
    for(int i = 0; i < NO; i++)
    {
       item = new ListViewItem("a1");
       item.SubItems.Add("a2");
       item.SubItems.Add("a3");
       listView1.Items.Add(item);
    }
