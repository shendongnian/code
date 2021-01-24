        private void CopytoolStripMenuItem1_Click(object sender, EventArgs e)        
          {
    	    ToolStripDropDownItem item = sender as ToolStripDropDownItem;
            if (item == null) // Error
                return;
            ContextMenuStrip strip = item.Owner as ContextMenuStrip;
            var grid = strip.SourceControl as DataGridView;
            if (grid == null) // Control wasn't a DGV
                return;
            switch (grid.Name)
            {
                case "dGVEL1":
                {
                    grid=dGVEL1;
                    break;
                }
            case "dGVEL2":
                {
                    grid=dGVEL2;
                    break;
                }
           }
        if (grid == null)  return;
        DataObject data = grid.GetClipboardContent();
        Clipboard.SetDataObject(data);
        }
