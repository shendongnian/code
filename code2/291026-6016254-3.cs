	for(int i = 1; i < 8; i++)
	{
		ToolStripMenuItem item = new ToolStripMenuItem();
		item.Text = "Set thickness: " + i;
		item.Click += toolStripMenuItemCommon_Click;
		item.Tag = i;
		
		// add item to strip container
	}
