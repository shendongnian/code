    foreach (ListViewItem lvi in listView1.Items)
    {
       double ItemText = Convert.ToDouble( lvi.Text) / Convert.ToDouble(textBox1.Text);
        lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, ItemText.ToString()));
    }
