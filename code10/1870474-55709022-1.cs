    ListViewItem item = new ListViewItem(rdr.GetString("ID"));
    item.SubItems.Add(rdr.GetString("Productnaam"));
    item.SubItems.Add(rdr.GetString("AnotherRow"));
    item.SubItems.Add(rdr.GetString("OneMoreForLuck"));
    listView1.Items.Add(item);
