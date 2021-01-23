    private void button1_Click(object sender, EventArgs e)
    {
        var itemsToRemove = new List<ListViewItem>();
    
        foreach (ListViewItem item in listView1.Items)
        {
            if (item.SubItems[0].Text == "A1")
                itemsToRemove.Add(item);
        }
    
        foreach (var item in itemsToRemove)
            listView1.Items.Remove(item);
    }
