    private void AddItemToListView(ListViewItem item, ListView listView)
    {
        if (listView.InvokeRequired)
        {
            listView.BeginInvoke((Action)delegate { AddItemToListView(item, listView); });
        }
        else
        {
            listView.Items.Add(item);
        }
    }
