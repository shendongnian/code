    private void Form1_Load(object sender, EventArgs e)
    {
        this.menuStrip1.Items[0].MouseHover += new EventHandler(Form1_MouseHover);
    }
     
    
    void Form1_MouseHover(object sender, EventArgs e)
    {
        if (sender is ToolStripDropDownItem)
        {
            ToolStripDropDownItem item = sender as ToolStripDropDownItem;
            if (item.HasDropDownItems && !item.DropDown.Visible)
            {
                item.ShowDropDown();
            }
        }
    }
