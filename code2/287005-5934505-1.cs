    protected void CreateTabFromTemplate(object sender, EventArgs e)
    {
        // create a new tab panel
        TabPanel newPanel = new TabPanel();
	newPanel.HeaderTemplate = TemplatePanel.HeaderTemplate;
	newPanel.ContentTemplate = TemplatePanel.ContentTemplate;
        // add the panel to the available tabs and select it
        TabContainer1.Tabs.Add(newPanel);
        TabContainer1.ActiveTab = newPanel;
    }
    protected void TabContainer_DataBinding(object sender, EventArgs e)
    {
       foreach(TabPanel panel in TabContainer.Tabs)
       {
          //identify if this is the correct tab
          if(correctTab)
          {
              // this will find a control anywhere on the panel (eg in both header and content templates)
              Label label = panel.FindControl("ControlID") as Label;
              label.Text = "Some Business Object Value";
          }
       }
    }
