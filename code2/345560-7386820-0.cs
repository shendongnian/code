    private void ConfigureTabs()
    {
        var config = GetConfig();
                
        foreach (TabPage tabPage in tabControl.TabPages)
        {
            if (config.IsTabVisible(tabPage.Name) == false)
            {
                tabControl.TabPages.Remove(tabPage);
            }
        }
    
        if (tabControl.TabPages.ContainsKey(config.DefaultTabName))
        {
            tabControl.SelectTab(config.DefaultTabName);
        }
    }
