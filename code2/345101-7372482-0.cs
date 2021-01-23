    private void listView1_ItemDrag(object sender, 
            System.Windows.Forms.ItemDragEventArgs e)
    {
        string[] files = GetSelection();
        if(files != null)
        {
            DoDragDrop(new DataObject(DataFormats.FileDrop, files), 
                       DragDropEffects.Copy | 
                       DragDropEffects.Move);
        }
    }
