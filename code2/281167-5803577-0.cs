    ToolStripMenuItem addContactToGroup = new ToolStripMenuItem();
    addContactToGroup.Name = "addContactToGroupToolStripMenuItem";
    addContactToGroup.Text = "Add Contact To Group";
    addContactToGroup.Click += new System.EventHandler(addContactToGroup_Click);
    this.contextMenuStripXtraGrid.Items.AddRange(new ToolStripItem[] { addContactToGroup });
    gridControl1.ContextMenuStrip = this.contextMenuStripXtraGrid;
