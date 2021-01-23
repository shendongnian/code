    private void listView1_DragEnter(object sender, DragEventArgs e)
    {
        if (!e.Data.GetDataPresent(typeof(ListView.ListViewItemCollection)))
        {
            e.Effect = DragDropEffects.None;
            return;
        }
    
        var items = (ListView.ListViewItemCollection)e.Data.GetData(typeof(ListView.ListViewItemCollection));
    
        if (items.Count > 0 && items[0].ListView != listView1)
        {
            e.Effect = DragDropEffects.None;
            return;
        }
    }
