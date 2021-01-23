                ContextMenuStrip contexMenuuu = new ContextMenuStrip();
    
                contexMenuuu.Items.Add("Edit ");
                contexMenuuu.Items.Add("Delete ");
                contexMenuuu.Show();
                contexMenuuu.ItemClicked += new ToolStripItemClickedEventHandler(contexMenuuu_ItemClicked);
    
    ...
    
            void contexMenuuu_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
                ToolStripItem item = e.ClickedItem;
                // your code here
            }
