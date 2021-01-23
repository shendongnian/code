    foreach (object o in menuStrip.Items)
    {
        if (o is ToolStripButton)
        {
            ToolStripItem item = (ToolStripItem)o;
            item.AllowDrop = true;
            item.DragEnter += new DragEventHandler(item_DragEnter);
            item.DragOver += new DragEventHandler(item_DragOver);
            item.DragDrop += new DragEventHandler(item_DragDrop);
        }
    }
    private void item_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormatName, false))
        {
            e.Effect = DragDropEffects.Move;
        }
    }
    private void item_DragOver(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormatName, false))
        {
            e.Effect = DragDropEffects.Move;
        }
    }
    private void item_DragDrop(object sender, DragEventArgs e)
    {
        int id = (int)e.Data.GetData(DataFormatName, false);
        int category = Convert.ToInt32((sender as ToolStripButton).Tag);
        MyFunction(category, id);
    }
