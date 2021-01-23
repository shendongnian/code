    listView1.BeginUpdate();
    ArrayList vSelectedItems = new ArrayList(listView1.SelectedItems);
    foreach (string item in vSelectedItems)
    {
       listView1.Items.Remove(item);
    }
    listView1.EndUpdate();
