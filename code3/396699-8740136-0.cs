    public void PopulateMenu(string fileName, ToolStripMenuItem parent)
    {
    	ToolStripMenuItem newMenu = new ToolStripMenuItem(fileName);
    	newMenu.Items.Add(new ToolStripMenuItem("View File"));
    	newMenu.Items.Add(new ToolStripMenuItem("Delete File"));
    	newMenu.Items.Add(new ToolStripMenuItem("Remove File"));
    	
    	parent.Items.Add(newMenu);
    }
