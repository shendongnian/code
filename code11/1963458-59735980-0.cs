    foreach (ListViewItem item in listView1.Items)
    {
        Debug.WriteLine($"Item: {item.Text}");
    
        foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
        {
            Debug.WriteLine($"\tSubitem:{subitem.Text}");
        }
    }
