    private void PopulateListView(Dictionary<string, string> items, ListView lv)
    {
        lv.Items.Clear();
        foreach (KeyValuePair<string, string> kvp in items)
        {
            ListViewItem lvi = new ListViewItem(kvp.Value);
            lvi.SubItems.Add(kvp.Key);
            lv.Items.Add(lvi);
        }
    }
